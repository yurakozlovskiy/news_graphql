using DAL.Repositories;
using GraphQL;
using GraphQL.Types;
using NewsGraphQL.Models.Types;

namespace NewsGraphQL.Models.Queries
{
    public class NewsQuery: ObjectGraphType
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
