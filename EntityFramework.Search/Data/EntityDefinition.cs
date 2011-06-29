using System;
using System.Collections.Generic;
using System.Linq;
using Lucene.Net.Documents;

namespace EntityFramework.Search.Data
{
    //public class UserIndexDefinition : IIndexDefinition<User>
    //{
    //    public Document Convert(User entity)
    //    {
    //        var document = new Document();

    //        document.AddField(new Field("userid", entity.UserId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
    //        document.AddField(new Field("firstname", entity.Firstname, Field.Store.YES, Field.Index.NOT_ANALYZED));
    //        document.AddField(new Field("lastname", entity.Lastname, Field.Store.YES, Field.Index.ANALYZED));

    //        return document;
    //    }

    //    public Term GetIndex(User entity)
    //    {
    //        return new Term("userid", entity.UserId.ToString());
    //    }
    //}

    public class EntityDefinition : IIndexDefinition<object>
    {
        public Document Convert(object entity)
        {
            var document = new Document();

            Type type = entity.GetType();

            foreach (var propInfo in type.GetProperties())
            {
                string name = propInfo.Name.ToLower();
                string value = propInfo.GetValue(entity, null).ToString();

                document.Add(new Field(name, value, Field.Store.YES, Field.Index.ANALYZED));
            }

            return document;
        }
    }
}
