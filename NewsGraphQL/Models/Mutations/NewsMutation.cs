using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using NewsGraphQL.Models.Types;
using NewsGraphQL.Models.InputTypes;
using DTO;

namespace NewsGraphQL.Models.Mutations
{
    public class NewsMutation: ObjectGraphType
    {
        public NewsMutation(INewsRepository newsRepository)
        {
            Field<NewsType>(
                "addNews",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<NewsInputType>> { Name = "news" }),
                resolve: context => newsRepository.Add(context.GetArgument<NewsDTO>("news"))
            );
        }
    }
}
