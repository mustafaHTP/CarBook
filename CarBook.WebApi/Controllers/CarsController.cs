using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.CarReviewDtos;
using CarBook.Application.Dtos.PricingPlanDtos;
using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarReviewFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private IMediator _mediator;

        public CarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCarsQuery();
            var cars = await _mediator.Send(query);
            var carsDto = cars.Select(c => new GetCarsDto()
            {
                Id = c.Id,
                ModelId = c.ModelId,
                ModelName = c.Model?.Name,
                BrandId = c.Model?.BrandId,
                BrandName = c.Model?.Brand?.Name,
                BigImageUrl = c.BigImageUrl,
                CoverImageUrl = c.CoverImageUrl,
                FuelType = c.FuelType,
                Km = c.Km,
                Luggage = c.Luggage,
                SeatCount = c.SeatCount,
                TransmissionType = c.TransmissionType
            });

            return Ok(carsDto);
        }

        [HttpGet("{id}/CarFeatures")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Car>))]
        public async Task<IActionResult> GetCarFeatures(int id)
        {
            var query = new GetCarFeaturesByCarIdQuery()
            {
                CarId = id
            };

            var carFeatures = await _mediator.Send(query);
            var carFeaturesDto = carFeatures.Select(cf => new GetCarFeaturesByCarIdDto
            {
                CarFeatureId = cf.CarFeatureId,
                CarId = cf.CarId,
                FeatureId = cf.FeatureId,
                FeatureName = cf.Feature.Name,
                IsAvailable = cf.IsAvailable
            });

            return Ok(carFeaturesDto);
        }

        [HttpGet("RentalPricings")]
        public async Task<IActionResult> GetAllRentalPricings()
        {
            var query = new GetCarRentalPricingsQuery();
            var carsWithRentalPricings = await _mediator.Send(query);
            var carsWithRentalPricingsDto = carsWithRentalPricings.Select(c => new GetCarsWithRentalPricingsDto
            {
                Car = new CarLiteDto
                {
                    Id = c.Id,
                    ModelId = c.ModelId,
                    ModelName = c.Model?.Name,
                    BrandId = c.Model?.BrandId ?? 0,
                    BrandName = c.Model?.Brand?.Name,
                    Km = c.Km,
                    SeatCount = c.SeatCount,
                    Luggage = c.Luggage,
                    TransmissionType = c.TransmissionType,
                    FuelType = c.FuelType,
                    CoverImageUrl = c.CoverImageUrl,
                    BigImageUrl = c.BigImageUrl
                },
                RentalPricings = c.CarReservationPricings.Select(crp => new RentalPeriodWithPriceDto
                {
                    Id = crp.CarId,
                    Name = crp.RentalPeriod.Name,
                    Price = crp.Price
                })
            });

            return Ok(carsWithRentalPricingsDto);
        }

        [HttpGet("{id}/RentalPricings")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Car>))]
        public async Task<IActionResult> GetRentalPricings(int id)
        {
            var query = new GetCarRentalPricingsByIdQuery()
            {
                CarId = id
            };
            var carRentalPricings = await _mediator.Send(query);
            var carRentalPricingsDto = carRentalPricings.Select(crp => new GetCarRentalPricingsByCarIdDto
            {
                Id = crp.CarId,
                CarId = crp.CarId,
                PricingPlanId = crp.PricingPlanId,
                PricingPlanName = crp.PricingPlan.Name,
                Price = crp.Price
            });

            return Ok(carRentalPricingsDto);
        }

        [HttpGet("{id}/CarDescriptions")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Car>))]
        public async Task<IActionResult> GetCarDescriptions(int id)
        {
            var query = new GetCarDescriptionsByCarIdQuery()
            {
                CarId = id
            };

            var carDescriptions = await _mediator.Send(query);
            var carDescriptionsDto = carDescriptions.Select(cf => new GetCarDescriptionsByCarIdDto
            {
                CarDescriptionId = cf.CarDescriptionId,
                CarId = cf.CarId,
                Description = cf.Description
            });

            return Ok(carDescriptionsDto);
        }

        [HttpGet("{id}/CarReviews")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Car>))]
        public async Task<IActionResult> GetCarReviewsByCarId(int id)
        {
            var query = new GetCarReviewsByCarIdQuery()
            {
                CarId = id
            };
            var carReviews = await _mediator.Send(query);
            var carReviewsDto = carReviews.Select(cr => new GetCarReviewByCarIdDto
            {
                CarId = cr.CarId,
                CustomerId = cr.CustomerId,
                CustomerFirstName = cr.Customer.FirstName,
                CustomerLastName = cr.Customer.LastName,
                CustomerEmail = cr.Customer.Email,
                Review = cr.Review,
                ReviewDate = cr.ReviewDate,
                RatingStarCount = cr.RatingStarCount
            });

            return Ok(carReviewsDto);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Car>))]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCarByIdQuery()
            {
                Id = id
            };

            var car = await _mediator.Send(query);
            var carDto = new GetCarByIdDto()
            {
                Id = car.Id,
                ModelId = car.ModelId,
                ModelName = car.Model?.Name,
                BrandId = car.Model?.BrandId ?? 0,
                BrandName = car.Model?.Brand?.Name,
                Km = car.Km,
                SeatCount = car.SeatCount,
                Luggage = car.Luggage,
                TransmissionType = car.TransmissionType,
                FuelType = car.FuelType,
                CoverImageUrl = car.CoverImageUrl,
                BigImageUrl = car.BigImageUrl
            };

            return Ok(carDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarDto createCarDto)
        {
            CreateCarCommand createCarCommand = new()
            {
                ModelId = createCarDto.ModelId,
                Km = createCarDto.Km,
                SeatCount = createCarDto.SeatCount,
                Luggage = createCarDto.Luggage,
                TransmissionType = createCarDto.TransmissionType,
                FuelType = createCarDto.FuelType,
                CoverImageUrl = createCarDto.CoverImageUrl,
                BigImageUrl = createCarDto.BigImageUrl
            };

            await _mediator.Send(createCarCommand);

            return Ok("Car has been created");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Car>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCarCommand(id);
            await _mediator.Send(command);

            return Ok("Car has been deleted");
        }


        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Car>))]
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateCarDto updateCarDto)
        {
            var updateCarCommand = new UpdateCarCommand()
            {
                Id = id,
                ModelId = updateCarDto.ModelId,
                Km = updateCarDto.Km,
                SeatCount = updateCarDto.SeatCount,
                Luggage = updateCarDto.Luggage,
                TransmissionType = updateCarDto.TransmissionType,
                FuelType = updateCarDto.FuelType,
                CoverImageUrl = updateCarDto.CoverImageUrl,
                BigImageUrl = updateCarDto.BigImageUrl
            };

            await _mediator.Send(updateCarCommand);

            return Ok("Car has been updated");
        }
    }
}
