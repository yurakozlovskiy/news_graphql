using System;
using GraphQL;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;
using NewsGraphQL.Models.Mutations;
using NewsGraphQL.Models.Queries;

namespace NewsGraphQL.Models.Schemes
{
    public class NewsSchema: Schema
    {
        public NewsSchema(IServiceProvider serviceProvider): base(serviceProvider)
        {
            Query = serviceProvider.GetRequiredService<NewsQuery>();
            Mutation = serviceProvider.GetRequiredService<NewsMutation>();
        }
    }
}
