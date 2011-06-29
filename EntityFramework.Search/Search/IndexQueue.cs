using System.Collections.Concurrent;
using Lucene.Net.Index;

namespace EntityFramework.Search.Search
{
    public interface IIndexTask
    {
        void Execute(IndexWriter writer);
    }

    public class IndexQueue
    {
        private static IndexQueue _indexQueue = new IndexQueue();
        private ConcurrentQueue<IIndexTask> _taskQueue = new ConcurrentQueue<IIndexTask>();

        public static IndexQueue Instance
        {
            get
            {
                return _indexQueue;
            }
        }

        public ConcurrentQueue<IIndexTask> Queue
        {
            get
            {
                return _taskQueue;
            }
        }

    }
}
