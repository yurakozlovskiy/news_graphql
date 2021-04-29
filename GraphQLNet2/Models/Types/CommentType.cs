using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;
using GraphQL.Types;

namespace GraphQLNet2.Models.Types
{
    public class CommentType : ObjectGraphType<CommentEntity>
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
