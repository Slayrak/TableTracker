using System;
using System.Threading.Tasks;

using MediatR;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using TableTracker.Application.CQRS.Reservations.Commands.AddReservation;
using TableTracker.Application.CQRS.Reservations.Commands.DeleteReservation;
using TableTracker.Application.CQRS.Reservations.Commands.UpdateReservation;
using TableTracker.Application.CQRS.Reservations.Queries.FindReservationById;
using TableTracker.Application.CQRS.Reservations.Queries.GetAllReservations;
using TableTracker.Application.CQRS.Reservations.Queries.GetAllReservationsByDate;
using TableTracker.Application.CQRS.Reservations.Queries.GetAllReservationsByDateAndTime;
using TableTracker.Application.CQRS.Reservations.Queries.GetAllReservationsForTable;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("api/reservations")]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("date-and-time")]
        public async Task<IActionResult> GetAllReservationsByDateAndTime(DateTime date)
        {
            var response = await _mediator.Send(new GetAllReservationsByDateAndTimeQuery(date));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("date")]
        public async Task<IActionResult> GetAllReservationsByDate(DateTime date)
        {
            var response = await _mediator.Send(new GetAllReservationsByDateQuery(date));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservations()
        {
            var response = await _mediator.Send(new GetAllReservationsQuery());

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByReservationId([FromRoute] long id)
        {
            var response = await _mediator.Send(new FindReservationByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddReservation([FromBody] ReservationDTO reservation)
        {
            var response = await _mediator.Send(new AddReservationCommand(reservation));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationDTO reservation)
        {
            var response = await _mediator.Send(new UpdateReservationCommand(reservation));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] long id)
        {
            var response = await _mediator.Send(new DeleteReservationCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }
    }
}
