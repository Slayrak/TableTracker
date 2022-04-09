﻿using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using TableTracker.Application.CQRS.Waiters.Commands.AddWaiter;
using TableTracker.Application.CQRS.Waiters.Commands.DeleteWaiter;
using TableTracker.Application.CQRS.Waiters.Commands.UpdateWaiter;
using TableTracker.Application.CQRS.Waiters.Queries.FindWaiterById;
using TableTracker.Application.CQRS.Waiters.Queries.GetAllWaiters;
using TableTracker.Application.CQRS.Waiters.Queries.GetAllWaitersByRestaurant;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    [Route("api/waiters")]
    [ApiController]
    public class WaiterController : ControllerBase
    {
        private readonly IMediator _mediator;

        public WaiterController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWaiters()
        {
            var response = await _mediator.Send(new GetAllWaitersQuery());

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindWaiterById(long id)
        {
            var response = await _mediator.Send(new FindWaiterByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("restaurant")]
        public async Task<IActionResult> GetAllWaitersByRestaurant([FromQuery] RestaurantDTO restaurant)
        {
            var response = await _mediator.Send(new GetAllWaitersByRestaurantQuery(restaurant));

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
    }
}
