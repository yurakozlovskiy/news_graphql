using DAL.Repositories;
using GraphQL;
using GraphQL.Types;
using GraphQLNet2.Models.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNet2.Models.Queries
{
    public class NewsQuery : ObjectGraphType
    {
        public NewsQuery(INewsRepository newsRepository)
        {
            Field<ListGraphType<NewsType>>("news", resolve: context => 
            {
                var news = newsRepository.GetAll();
                return news;
            });

            Field<NewsType>(
                "newsById",
                arguments: new QueryArguments(new QueryArgument<StringGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var news = newsRepository.GetById(context.GetArgument<string>("id"));
                    if (news == null)
                        throw new System.Exception("Invalid id");
                    return news;
                }
            );
        }
    }
}
