using EntityFramework.Search.Search;
using Lucene.Net.Documents;
using Lucene.Net.Index;

namespace EntityFramework.Search.Data
{
    public class EntityUpdateTask : IIndexTask
    {
        private readonly EntityDefinition _definition;
        private readonly object _entity;

        public EntityUpdateTask(object entity, EntityDefinition definition)
        {
            _entity = entity;
            _definition = definition;
        }

        public void Execute(IndexWriter writer)
        {
            Document document = _definition.Convert(_entity);
            writer.AddDocument(document);
        }
    }
}
