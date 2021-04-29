using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLNet2.Models.Types;
using GraphQLNet2.Models.InputTypes;
using DTO;
using DAL.Repositories;

namespace GraphQLNet2.Models.Mutations
{
    public class NewsMutation: ObjectGraphType
    {
        public NewsMutation(INewsRepository newsRepository)
        {
            Field<NewsType>(
                "addNews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<NewsInputType>> { Name = "news" }),
                resolve: context =>
                {
                    var n = context.GetArgument<NewsDTO>("news");
                    return newsRepository.AddAndGet(n);
                }
            );
        }
    }
}
