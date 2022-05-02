using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TableTracker.Application.CQRS.VisitorFavourites.Commands.AddVisitorFavourite;
using TableTracker.Application.CQRS.VisitorFavourites.Commands.DeleteVisitorFavourite;
using TableTracker.Application.CQRS.VisitorFavourites.Commands.UpdateVisitorFavourite;
using TableTracker.Application.CQRS.VisitorFavourites.Queries.FindVisitorFavouriteById;
using TableTracker.Application.CQRS.VisitorFavourites.Queries.GetAllVisitorFavourites;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/visitorfavourites")]
    public class VisitorFavouriteController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VisitorFavouriteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisitorFavourites()
        {
            var response = await _mediator.Send(new GetAllVisitorFavouritesQuery());

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindVisitorFavouriteById([FromRoute] long id)
        {
            var response = await _mediator.Send(new FindVisitorFavouriteByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitorFavourite([FromQuery] VisitorFavouriteDTO visit)
        {
            var response = await _mediator.Send(new AddVisitorFavouriteCommand(visit));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVisitorFavourite([FromQuery] VisitorFavouriteDTO visit)
        {
            var response = await _mediator.Send(new UpdateVisitorFavouriteCommand(visit));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVisitorFavourite([FromRoute] long id)
        {
            var response = await _mediator.Send(new DeleteVisitorFavouriteCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }
    }
}
