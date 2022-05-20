using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TableTracker.Application.CQRS.Visitors.Commands.AddVisitor;
using TableTracker.Application.CQRS.Visitors.Commands.AddVisitorFavourite;
using TableTracker.Application.CQRS.Visitors.Commands.DeleteVisitorFavourite;
using TableTracker.Application.CQRS.Visitors.Commands.UpdateVisitor;
using TableTracker.Application.CQRS.Visitors.Queries.FindVisitorByFind;
using TableTracker.Application.CQRS.Visitors.Queries.FindVisitorFavouritesByVisitorId;
using TableTracker.Application.CQRS.Visitors.Queries.GetAllVisitors;
using TableTracker.Application.CQRS.Visitors.Queries.GetAllVisitorsByTrustFactor;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/visitors")]
    public class VisitorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VisitorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllVisitors()
        {
            var response = await _mediator.Send(new GetAllVisitorsQuery());

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindVisitorById([FromRoute] long id)
        {
            var response = await _mediator.Send(new FindVisitorByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("trust")]
        public async Task<IActionResult> GetAllVisitorsByTrustFactor(float trust)
        {
            var response = await _mediator.Send(new GetAllVisitorsByTrustFactorQuery(trust));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddVisitor([FromBody] VisitorDTO visitor)
        {
            var response = await _mediator.Send(new AddVisitorCommand(visitor));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateVisitor([FromBody] VisitorDTO visitor)
        {
            var response = await _mediator.Send(new UpdateVisitorCommand(visitor));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteVisitor([FromBody] VisitorDTO visitor)
        {
            var response = await _mediator.Send(new AddVisitorCommand(visitor));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet("{id}/favourites")]
        public async Task<IActionResult> FindVisitorFavouriteByVisitorId([FromRoute] long id)
        {
            var response = await _mediator.Send(new FindVisitorFavouritesByVisitorIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost("{id}/favourites")]
        public async Task<IActionResult> AddVisitorFavourite([FromRoute] long id, long restaurantId)
        {
            var response = await _mediator.Send(new AddVisitorFavouriteCommand(id, restaurantId));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}/favourites")]
        public async Task<IActionResult> DeleteVisitorFavourite([FromRoute] long id, long restaurantId)
        {
            var response = await _mediator.Send(new DeleteVisitorFavouriteCommand(id, restaurantId));

            return ReturnResultHelper.ReturnCommandResult(response);
        }
    }
}
