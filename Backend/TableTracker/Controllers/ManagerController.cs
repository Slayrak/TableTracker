using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TableTracker.Application.Managers.Commands.AddManager;
using TableTracker.Application.Managers.Commands.DeleteManager;
using TableTracker.Application.Managers.Commands.UpdateManager;
using TableTracker.Application.Managers.Queries.FindManagerById;
using TableTracker.Application.Managers.Queries.FindManagerByRestaurant;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    [Route("api/manager")]
    [ApiController]
    public class ManagerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ManagerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindManagerById(long id)
        {
            var response = await _mediator.Send(new FindManagerByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddManager([FromBody] ManagerDTO managerDTO)
        {
            var response = await _mediator.Send(new AddManagerCommand(managerDTO));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateManager([FromBody] ManagerDTO managerDTO)
        {
            var response = await _mediator.Send(new UpdateManagerCommand(managerDTO));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteManager(long id)
        {
            var response = await _mediator.Send(new DeleteManagerCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet("restaurant")]
        public async Task<IActionResult> FindManagerByRestaurant([FromQuery] RestaurantDTO restaurantDTO)
        {
            var response = await _mediator.Send(new FindManagerByRestaurantQuery(restaurantDTO));

            return ReturnResultHelper.ReturnQueryResult(response);
        }
    }
}
