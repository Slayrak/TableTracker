using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using TableTracker.Application.CQRS.Franchises.Commands.AddFranchise;
using TableTracker.Application.CQRS.Franchises.Commands.DeleteFranchise;
using TableTracker.Application.CQRS.Franchises.Commands.UpdateFranchise;
using TableTracker.Application.CQRS.Franchises.Queries.FindFranchiseById;
using TableTracker.Application.CQRS.Franchises.Queries.GetAllFranchises;
using TableTracker.Application.CQRS.Franchises.Queries.GetFranchiseByName;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    [ApiController]
    [Route("api/franchises")]
    public class FranchiseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FranchiseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindFranchiseById(long id)
        {
            var response = await _mediator.Send(new FindFranchiseByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("/{name}")]
        public async Task<IActionResult> GetFranchiseByName(string name)
        {
            var response = await _mediator.Send(new GetFranchiseByNameQuery(name));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFranchises()
        {
            var response = await _mediator.Send(new GetAllFranchisesQuery());

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddFranchise([FromBody] FranchiseDTO franchise)
        {
            var response = await _mediator.Send(new AddFranchiseCommand(franchise));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateFranchise([FromBody] FranchiseDTO franchise)
        {
            var response = await _mediator.Send(new UpdateFranchiseCommand(franchise));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteFranchiseById(long id)
        {
            var response = await _mediator.Send(new DeleteFranchiseCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }
    }
}
