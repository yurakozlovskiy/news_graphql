using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL.Types;

namespace GraphQLNet2.Models.InputTypes
{
    public class NewsInputType : InputObjectGraphType
    {
        public NewsInputType()
        {
            Name = "NewsInput";
            Field<StringGraphType>("title");
            Field<StringGraphType>("description");
            Field<StringGraphType>("author");
            Field<StringGraphType>("url");
            Field<ListGraphType<StringGraphType>>("categories");
            Field<DateGraphType>("publicationDate");
        }
    }
}
