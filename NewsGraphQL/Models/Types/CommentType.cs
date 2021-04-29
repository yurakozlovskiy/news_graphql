using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;
using DTO;
using DAL.Entities;

namespace NewsGraphQL.Models.Types
{
    public class CommentType: ObjectGraphType<CommentEntity>
    {
        public CommentType()
        {
            Field(x => x.Id, true);
            Field(x => x.Author, true);
            Field(x => x.PostDate, true);
            Field(x => x.Text, true);
        }
    }
}
