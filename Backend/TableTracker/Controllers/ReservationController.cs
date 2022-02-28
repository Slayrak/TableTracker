using MediatR;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using TableTracker.Application.Reservations.Commands.AddReservation;
using TableTracker.Application.Reservations.Commands.DeleteReservation;
using TableTracker.Application.Reservations.Commands.UpdateReservation;
using TableTracker.Application.Reservations.Queries.FindReservationById;
using TableTracker.Application.Reservations.Queries.GetAllReservationsByDate;
using TableTracker.Application.Reservations.Queries.GetAllReservationsForTable;
using TableTracker.Domain.DataTransferObjects;
using TableTracker.Domain.Enums;
using TableTracker.Helpers;

namespace TableTracker.Controllers
{
    [Route("api/reservations")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> FindByReservationId(long id)
        {
            var response = await _mediator.Send(new FindReservationByIdQuery(id));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddReservation([FromBody] ReservationDTO reservation)
        {
            var response = await _mediator.Send(new AddReservationCommand(reservation));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationDTO reservation)
        {
            var response = await _mediator.Send(new UpdateReservationCommand(reservation));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteReservation(long id)
        {
            var response = await _mediator.Send(new DeleteReservationCommand(id));

            return ReturnResultHelper.ReturnCommandResult(response);
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetAllReservationsByDate(DateTime date)
        {
            var response = await _mediator.Send(new GetAllReservationsByDateQuery(date));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservationsForTable(ReservationFilterModel model)
        {
            var response = await _mediator.Send(new GetAllReservationsForTableQuery(model));

            return ReturnResultHelper.ReturnQueryResult(response);
        }

    }
}
