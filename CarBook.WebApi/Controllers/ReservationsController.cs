using CarBook.Application.Dtos.ReservationDtos;
using CarBook.Application.Features.ReservationFeatures.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateReservationDto createReservationDto)
        {
            var command = new CreateReservationCommand()
            {
                CarId = createReservationDto.CarId,
                CustomerName = createReservationDto.CustomerFirstName,
                CustomerLastName = createReservationDto.CustomerLastName,
                CustomerEmail = createReservationDto.CustomerEmail,
                CustomerAge = createReservationDto.CustomerAge,
                CustomerDriverLicenseYear = createReservationDto.CustomerDriverLicenseYear,
                Description = createReservationDto.Description,
                PickUpLocationId = createReservationDto.PickUpLocationId,
                DropOffLocationId = createReservationDto.DropOffLocationId
            };

            await _mediator.Send(command);

            return Ok();
        }
    }
}
