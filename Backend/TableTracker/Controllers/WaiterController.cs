using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TableTracker.Application.Waiters.Commands.AddWaiter;
using TableTracker.Application.Waiters.Commands.DeleteWaiter;
using TableTracker.Application.Waiters.Commands.UpdateWaiter;
using TableTracker.Application.Waiters.Queries.FindWaiterById;
using TableTracker.Application.Waiters.Queries.GetAllWaiterByRestaurant;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaiterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WaiterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindWaiterById(long id)
        {
            var response = await _mediator.Send(new FindWaiterByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddWaiter([FromBody] WaiterDTO waiter)
        {
            var response = await _mediator.Send(new AddWaiterCommand(waiter));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateWaiter([FromBody] WaiterDTO waiter)
        {
            var response = await _mediator.Send(new UpdateWaiterCommand(waiter));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteWaiter(long id)
        {
            var response = await _mediator.Send(new DeleteWaiterCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet("restaurant")]
        public async Task<IActionResult> GetAllWaiterByRestaurant([FromQuery] RestaurantDTO restaurant)
        {
            var response = await _mediator.Send(new GetAllWaiterByRestaurantQuery(restaurant));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

    }
}
