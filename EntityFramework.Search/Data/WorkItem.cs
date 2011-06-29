using System.Data;

namespace EntityFramework.Search.Data
{
    public class WorkItem
    {
        public EntityKey Key { get; set; }
        public object Entity { get; set; }
        public EntityState State { get; set; }
    }
}
