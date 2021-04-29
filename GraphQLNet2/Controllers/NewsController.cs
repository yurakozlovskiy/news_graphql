using GraphQL;
using GraphQL.Types;
using GraphQLNet2.Models.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GraphQLNet2.Controllers
{
    [Route("graphql")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly ISchema _schema;
        private readonly IDocumentExecuter _documentExecutor;

        public NewsController(IDocumentExecuter documentExecuter, ISchema schema)
        {
            _documentExecutor = documentExecuter;
            _schema = schema;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] GraphQLQuery query)
        {
            if (query == null)
            {
                throw new Exception(nameof(query));
            }

            var executionOptions = new ExecutionOptions
            {
                Schema = _schema,
                Query = query.Query,
                Inputs = query.Variables?.ToInputs()
            };

            var result = await _documentExecutor.ExecuteAsync(executionOptions).ConfigureAwait(false);

            if (result.Errors?.Count > 0)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
