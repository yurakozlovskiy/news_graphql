using GraphQL.SystemTextJson;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace NewsGraphQL.Models.Queries
{
    public class GraphQLQuery
    {
        public string OperationName { get; set; }
        public string NamedQuery { get; set; }
        public string Query { get; set; }

        //public JObject Variables { get; set; }
        [JsonConverter(typeof(ObjectDictionaryConverter))]
        public Dictionary<string, object> Variables { get; set; }
    }
}
