using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using DTO;
using DAL.Entities;

namespace NewsGraphQL.Models.Types
{
    public class NewsType: ObjectGraphType<NewsEntity>
    {
        public NewsType()
        {
            Field(x => x.Id, true);
            Field(x => x.Title, true);
            Field(x => x.Description, true);
            Field(x => x.Author, true);
            //Field(x => x.Category, true);
            Field(x => x.Url, true);
            Field(x => x.MainUrl, true);
            Field(x => x.ViewsCount, true);
            Field(x => x.PublicationDate, true);
            Field(x => x.UploadedDate, true);
        }
    }
}
