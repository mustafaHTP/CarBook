using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Dtos.CarDtos;
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
                LocationName = rc.Location.Name,
                CarId = rc.CarId,
                Car = new CarWithReservationPricingsDto
                {
                    Id = rc.Car.Id,
                    BrandId = rc.Car.Model.BrandId,
                    BrandName = rc.Car.Model.Brand.Name,
                    ModelId = rc.Car.ModelId,
                    ModelName = rc.Car.Model.Name,
                    Km = rc.Car.Km,
                    SeatCount = rc.Car.SeatCount,
                    Luggage = rc.Car.Luggage,
                    TransmissionType = rc.Car.TransmissionType,
                    FuelType = rc.Car.FuelType,
                    CoverImageUrl = rc.Car.CoverImageUrl,
                    BigImageUrl = rc.Car.BigImageUrl,
                    CarReservationPricings = rc.Car.CarReservationPricings
                },
                IsAvailable = rc.IsAvailable,
            });

            return Ok(GenericApiResponse<IEnumerable<GetRentalCarsDto>>.Success(rentalCarsDto));
        }
    }
}
