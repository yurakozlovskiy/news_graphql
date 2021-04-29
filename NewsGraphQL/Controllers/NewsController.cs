using GraphQL;
using GraphQL.Types;
using Microsoft.AspNetCore.Mvc;
using NewsGraphQL.Models.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Net;
using Microsoft.AspNetCore.Http;

namespace NewsGraphQL.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly IDocumentExecuter _documentExecuter;
        //private readonly IDocumentWriter _documentWriter;
        private readonly ISchema _schema;

        public NewsController(ISchema schema, IDocumentExecuter documentExecuter)
        {
            _schema = schema;
            _documentExecuter = documentExecuter;
            //_documentWriter = documentWriter;
        }

        public IActionResult Index()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables?.ToInputs()
            };

            var result = await _documentExecuter.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
