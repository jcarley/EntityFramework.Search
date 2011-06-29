using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Objects;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EntityFramework.Search.Search;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Store;

using DirectoryService = Lucene.Net.Store.Directory;

namespace EntityFramework.Search.Data
{
    public partial class WatercoolerEntities
    {
        private IList<WorkItem> _workItems = null;

        partial void OnContextCreated()
        {
            base.SavingChanges += new EventHandler(WatercoolerEntities_SavingChanges);
        }

        private void WatercoolerEntities_SavingChanges(object sender, EventArgs e)
        {
            // Grab the entities that are going to be saved.

            var osm = ObjectStateManager;

            _workItems = (from entry in osm.GetObjectStateEntries(EntityState.Added | EntityState.Deleted | EntityState.Modified)
                          select new WorkItem()
                          {
                              Key = entry.EntityKey,
                              Entity = entry.Entity,
                              State = entry.State
                          }).ToList();

            var count = _workItems.Count;
        }

        public override int SaveChanges(SaveOptions options)
        {
            int affectedRecords = -1;

            try
            {
                affectedRecords = base.SaveChanges(options);

                if (affectedRecords > 0)
                {
                    // process worker queue
                    foreach (var item in _workItems)
                    {
                        // we are going to assume that if we got here, its ok to process
                        // every work item
                        IIndexTask task = null;

                        if (item.State == EntityState.Deleted)
                        {
                            // need to create a unique key and value
                            var key = item.Key.EntityKeyValues.ElementAt(0).Key;

                            var value = item.Key.EntityKeyValues.ElementAt(0).Value;

                            task = new EntityDeleteTask(key, value.ToString());
                        }
                        else
                        {
                            EntityDefinition definition = new EntityDefinition();

                            task = new EntityUpdateTask(item.Entity, definition);
                        }

                        IndexQueue.Instance.Queue.Enqueue(task);

                    }

                    Task.Factory.StartNew(ProcessIndexQueue);
                }

            }
            catch (Exception ex)
            {
                // remove items from worker queue
                throw;
            }

            return affectedRecords;

        }

        private void ProcessIndexQueue()
        {
            IIndexTask task = null;

            var indexPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Index");

            DirectoryService directory = FSDirectory.GetDirectory(indexPath);

            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_29);

            IndexWriter writer = new IndexWriter(directory, analyzer);

            while (IndexQueue.Instance.Queue.TryDequeue(out task))
            {
                task.Execute(writer);
            }

            writer.Commit();
            writer.Optimize();
            writer.Flush();
            writer.Close();

        }
    }
}
