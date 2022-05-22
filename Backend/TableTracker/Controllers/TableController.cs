using System;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TableTracker.Application.CQRS.Reservations.Queries.GetAllReservationsForTable;
using TableTracker.Application.CQRS.Tables.Commands.AddTable;
using TableTracker.Application.CQRS.Tables.Commands.DeleteTable;
using TableTracker.Application.CQRS.Tables.Commands.UpdateTable;
using TableTracker.Application.CQRS.Tables.Queries.FindTableById;
using TableTracker.Application.CQRS.Tables.Queries.GetAllTablesByRestaurant;
using TableTracker.Application.CQRS.Tables.Queries.GetAllTablesWithFiltering;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/tables")]
    public class TableController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TableController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindTableById([FromRoute] long id)
        {
            var response = await _mediator.Send(new FindTableByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddTable([FromBody] TableDTO table)
        {
            var response = await _mediator.Send(new AddTableCommand(table));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateTable([FromBody] TableDTO table)
        {
            var response = await _mediator.Send(new UpdateTableCommand(table));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTable([FromRoute] long id)
        {
            var response = await _mediator.Send(new DeleteTableCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet("restaurant/{id}")]
        public async Task<IActionResult> FindTableByRestaurantId([FromRoute] long id)
        {
            var response = await _mediator.Send(new GetAllTablesByRestaurantQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}/reservations/")]
        public async Task<IActionResult> GetAllReservationsForTable([FromRoute] long id, [FromQuery] DateTime date)
        {
            var response = await _mediator.Send(new GetAllReservationsForTableQuery(id, date.AddHours(3)));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        //[HttpGet]
        //public async Task<IActionResult> GetAllTablesWithFiltering([FromQuery] TableFilterModel tableFilterModel)
        //{
        //    var response = await _mediator.Send(new GetAllTablesWithFilteringQuery(tableFilterModel));

        //    return ReturnResultHelper.ReturnQueryResult(response);
        //}
    }
}
