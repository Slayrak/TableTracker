using System;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using TableTracker.Application.Restaurants.Commands.AddRestaurant;
using TableTracker.Application.Restaurants.Queries.FindRestaurantById;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Enums;

namespace TableTracker.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RestaurantController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindById(long id)
        {
            var response = await _mediator.Send(new FindRestaurantByIdQuery(id));

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> FindRestaurantById([FromBody] RestaurantDTO restaurant)
        {
            var response = await _mediator.Send(new AddRestaurantCommand(restaurant));

            return response.Result switch
            {
                CommandResult.NotFound => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Failure => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Success => new OkObjectResult(response.Object),
                _ => throw new NotSupportedException(),
            };
        }
    }
}
