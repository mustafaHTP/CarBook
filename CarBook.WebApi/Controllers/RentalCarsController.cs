using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Dtos.RentalCarDtos;
using CarBook.Application.Features.RentalCarFeatures.Queries;
using CarBook.WebApi.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentalCarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentalCarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetRentalCarsQueryDto getRentalCarsQueryDto)
        {
            var rentalCars = await _mediator.Send(
                new GetRentalCarsQuery
                {
                    PickUpLocationId = getRentalCarsQueryDto.PickUpLocationId,
                });
            var rentalCarsDto = rentalCars.Select(rc => new GetRentalCarsDto()
            {
                Id = rc.Id,
                LocationId = rc.LocationId,
                Location = rc.Location,
                CarId = rc.CarId,
                Car = rc.Car,
                IsAvailable = rc.IsAvailable,
            });

            return Ok(GenericApiResponse<IEnumerable<GetRentalCarsDto>>.Success(rentalCarsDto));
        }
    }
}
