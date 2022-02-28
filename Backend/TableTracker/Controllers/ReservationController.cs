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

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }

        [HttpPost("add")]
        public async Task<IActionResult> AddReservation([FromBody] ReservationDTO reservation)
        {
            var response = await _mediator.Send(new AddReservationCommand(reservation));

            return response.Result switch
            {
                CommandResult.NotFound => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Failure => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Success => new OkObjectResult(response.Object),
                _ => throw new NotSupportedException(),
            };
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateReservation([FromBody] ReservationDTO reservation)
        {
            var response = await _mediator.Send(new UpdateReservationCommand(reservation));

            return response.Result switch
            {
                CommandResult.NotFound => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Failure => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Success => new OkObjectResult(response.Object),
                _ => throw new NotSupportedException(),
            };
        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteReservation(long id)
        {
            var response = await _mediator.Send(new DeleteReservationCommand(id));

            return response.Result switch
            {
                CommandResult.NotFound => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Failure => new NotFoundObjectResult(response.ErrorMessage),
                CommandResult.Success => new OkObjectResult(response.Object),
                _ => throw new NotSupportedException(),
            };
        }

        [HttpGet("date/{date}")]
        public async Task<IActionResult> GetAllReservationsByDate(DateTime date)
        {
            var response = await _mediator.Send(new GetAllReservationsByDateQuery(date));

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }

        [HttpGet]
        public async Task<IActionResult> GetAllReservationsForTable(ReservationFilterModel model)
        {
            var response = await _mediator.Send(new GetAllReservationsForTableQuery(model));

            return response switch
            {
                null => new NotFoundObjectResult("Object could not be found"),
                _ => new OkObjectResult(response),
            };
        }

    }
}
