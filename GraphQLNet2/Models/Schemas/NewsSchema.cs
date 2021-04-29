using GraphQL.Types;
using GraphQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQLNet2.Models.Queries;
using GraphQLNet2.Models.Mutations;

namespace GraphQLNet2.Models.Schemas
{
    public class NewsSchema : Schema
    {
        public NewsSchema(IDependencyResolver resolver): base(resolver)
        {
            Query = resolver.Resolve<NewsQuery>();
            Mutation = resolver.Resolve<NewsMutation>();
        }
    }
}
