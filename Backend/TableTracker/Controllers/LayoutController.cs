using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TableTracker.Application.Layout.Commands;
using TableTracker.Application.Layout.Commands.AddLayout;
using TableTracker.Application.Layout.Commands.DeleteLayout;
using TableTracker.Application.Layout.Commands.UpdateLayout;
using TableTracker.Application.Layout.Queries.FindLayoutById;
using TableTracker.Application.Layout.Queries.FindLayoutByRestaurant;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    [Route("api/layouts")]
    [ApiController]
    public class LayoutController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LayoutController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindLayoutById(long id)
        {
            var response = await _mediator.Send(new FindLayoutByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddLayout([FromBody] LayoutDTO layoutDTO)
        {
            var response = await _mediator.Send(new AddLayoutCommand(layoutDTO));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateLayout([FromBody] LayoutDTO layoutDTO)
        {
            var response = await _mediator.Send(new UpdateLayoutCommand(layoutDTO));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> DeleteLayout(long id)
        {
            var response = await _mediator.Send(new DeleteLayoutCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet("restaurant")]
        public async Task<IActionResult> FindLayoutByRestaurant([FromQuery] RestaurantDTO restaurantDTO)
        {
            var response = await _mediator.Send(new FindLayoutByRestaurantQuery(restaurantDTO));

            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
