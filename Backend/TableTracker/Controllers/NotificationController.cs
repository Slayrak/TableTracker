using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Mvc;

using TableTracker.Domain.DataTransferObjects;

namespace TableTracker.Controllers
{
    [ApiController]
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("faq-email")]
        public async Task<IActionResult> SendFAQEmail([FromBody] EmailDTO email)
        {
            var response = _mediator.Send(new )
        }
    }
}
