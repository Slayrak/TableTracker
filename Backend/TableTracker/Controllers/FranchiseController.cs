using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using TableTracker.Application.Franchises.Queries.FindFranchiseById;
using TableTracker.Application.Franchises.Queries.GetAllFranchises;
using TableTracker.Application.Franchises.Queries.GetFranchiseByName;

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

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }

        [HttpGet("/{name}")]
        public async Task<IActionResult> GetFranchiseByName(string name)
        {
            var response = await _mediator.Send(new GetFranchiseByNameQuery(name));

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFranchises()
        {
            var response = await _mediator.Send(new GetAllFranchisesQuery());

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }

        [HttpDelete("delete/{id}")]
        public async void DeleteFranchiseById(long id)
        {
            var response = await _mediator.Send(new GetAllFranchisesQuery());

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }
    }
}
