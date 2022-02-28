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
using TableTracker.Helpers;

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

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddTable([FromBody] TableDTO table)
        {
            var response = await _mediator.Send(new AddTableCommand(table));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateRestaurant([FromBody] TableDTO table)
        {
            var response = await _mediator.Send(new UpdateTableCommand(table));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRestaurant(long id)
        {
            var response = await _mediator.Send(new DeleteTableCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTablesWithFiltering(TableFilterModel tableFilterModel)
        {
            var response = await _mediator.Send(new GetAllTablesWithFilteringQuery(tableFilterModel));

            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
