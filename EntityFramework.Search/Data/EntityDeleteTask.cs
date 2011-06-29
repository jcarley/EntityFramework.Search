using EntityFramework.Search.Search;
using Lucene.Net.Index;

namespace EntityFramework.Search.Data
{
    public class EntityDeleteTask : IIndexTask
    {
        public EntityDeleteTask(string key, string value)
        {
        }

        public void Execute(IndexWriter writer)
        {

        }
    }
}
