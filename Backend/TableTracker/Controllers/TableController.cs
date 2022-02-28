using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TableTracker.Application.Tables.Commands.AddTable;
using TableTracker.Application.Tables.Commands.DeleteTable;
using TableTracker.Application.Tables.Commands.UpdateTable;
using TableTracker.Application.Tables.Queries.FindTableById;
using TableTracker.Application.Tables.Queries.GetAllTablesWithFiltering;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Enums;

namespace TableTracker.Controllers
{
    [Route("api/tables")]
    [ApiController]
    public class TableController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindTableById(long id)
        {
            var response = await _mediator.Send(new FindTableByIdQuery(id));

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTable([FromBody] TableDTO table)
        {
            var response = await _mediator.Send(new AddTableCommand(table));

            return response.Result switch
            {
                CommandResult.NotFound => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Failure => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Success => new OkObjectResult(response.Object),
                _ => throw new NotSupportedException(),
            };
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRestaurant([FromBody] TableDTO table)
        {
            var response = await _mediator.Send(new UpdateTableCommand(table));

            return response.Result switch
            {
                CommandResult.NotFound => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Failure => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Success => new OkObjectResult(response.Object),
                _ => throw new NotSupportedException(),
            };
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRestaurant(long id)
        {
            var response = await _mediator.Send(new DeleteTableCommand(id));

            return response.Result switch
            {
                CommandResult.NotFound => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Failure => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Success => new OkObjectResult(response.Object),
                _ => throw new NotSupportedException(),
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTablesWithFiltering(TableFilterModel tableFilterModel)
        {
            var response = await _mediator.Send(new GetAllTablesWithFilteringQuery(tableFilterModel));

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }
    }
}
