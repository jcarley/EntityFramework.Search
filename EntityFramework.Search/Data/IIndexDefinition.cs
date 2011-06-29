using Lucene.Net.Documents;

namespace EntityFramework.Search.Data
{
    public interface IIndexDefinition<T>
        where T : class
    {
        Document Convert(T entity);
    }
}
