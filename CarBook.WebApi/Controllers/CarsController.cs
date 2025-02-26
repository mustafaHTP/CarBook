using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Dtos.CarReviewDtos;
using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Features.CarFeatures.Queries;
using CarBook.Application.Features.CarReviewFeatures.Queries;
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
        public async Task<IActionResult> GetAll([FromQuery] GetCarsQueryDto getCarsQueryDto)
        {
            var query = new GetCarsQuery
            {
                IncludeBrand = getCarsQueryDto.IncludeBrand,
                IncludeModel = getCarsQueryDto.IncludeModel
            };
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

        [HttpGet("{carId}/CarFeatures")]
        public async Task<IActionResult> GetCarFeatures(int carId)
        {
            var query = new GetCarFeaturesByCarIdQuery()
            {
                CarId = carId
            };

            var carFeatures =  await _mediator.Send(query);
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
        public async Task<IActionResult> GetAllRentalPricings([FromQuery] GetCarRentalPricingsQueryDto getCarRentalPricingsQueryDto)
        {
            var query = new GetCarRentalPricingsQuery
            {
                IncludeCar = getCarRentalPricingsQueryDto.IncludeCar
            };
            var carRentalPricings = await _mediator.Send(query);
            var carRentalPricingsDto = carRentalPricings.Select(crp => new GetCarRentalPricingsDto
            {
                Id = crp.CarId,
                Car = new CarLiteDto
                {
                    Id = crp.Car.Id,
                    ModelId = crp.Car.ModelId,
                    ModelName = crp.Car.Model.Name,
                    BrandId = crp.Car.Model.BrandId,
                    BrandName = crp.Car.Model.Brand.Name,
                    BigImageUrl = crp.Car.BigImageUrl,
                    FuelType = crp.Car.FuelType,
                    Km = crp.Car.Km,
                    Luggage = crp.Car.Luggage,
                    SeatCount = crp.Car.SeatCount,
                    TransmissionType = crp.Car.TransmissionType,
                    CoverImageUrl = crp.Car.CoverImageUrl,
                },
                CarId = crp.CarId,
                PricingPlanId = crp.PricingPlanId,
                PricingPlanName = crp.PricingPlan.Name,
                Price = crp.Price
            });

            return Ok(carRentalPricingsDto);
        }

        [HttpGet("{carId}/RentalPricings")]
        public async Task<IActionResult> GetRentalPricings(int carId)
        {
            var query = new GetCarRentalPricingsByIdQuery()
            {
                CarId = carId
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

        [HttpGet("{carId}/CarDescriptions")]
        public async Task<IActionResult> GetCarDescriptions(int carId)
        {
            var query = new GetCarDescriptionsByCarIdQuery()
            {
                CarId = carId
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

        [HttpGet("{carId}/CarReviews")]
        public async Task<IActionResult> GetCarReviewsByCarId(int carId)
        {
            var query = new GetCarReviewsByCarIdQuery()
            {
                CarId = carId
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

        [HttpGet("GetAllWithModel")]
        public async Task<IActionResult> GetAllWithModel()
        {
            var cars = await _mediator.Send(new GetCarsWithModelQuery());
            var carsDto = cars.Select(c => new GetCarsWithModelDto()
            {
                Id = c.Id,
                ModelId = c.ModelId,
                Model = c.Model,
                BigImageUrl = c.BigImageUrl,
                CoverImageUrl = c.CoverImageUrl,
                FuelType = c.FuelType,
                Km = c.Km,
                Luggage = c.Luggage,
                SeatCount = c.SeatCount,
                TransmissionType = c.TransmissionType,
            });

            return Ok(carsDto);
        }

        [HttpGet("GetAllWithBrand")]
        public async Task<IActionResult> GetAllWithBrand()
        {
            var cars = await _mediator.Send(new GetCarsWithBrandQuery());
            var carsDto = cars.Select(c => new GetCarsWithBrandDto()
            {
                Id = c.Id,
                ModelId = c.ModelId,
                Model = c.Model,
                BrandId = c.BrandId,
                Brand = c.Brand,
                BigImageUrl = c.BigImageUrl,
                CoverImageUrl = c.CoverImageUrl,
                FuelType = c.FuelType,
                Km = c.Km,
                Luggage = c.Luggage,
                SeatCount = c.SeatCount,
                TransmissionType = c.TransmissionType,
            });

            return Ok(carsDto);
        }

        [HttpGet("GetLast5CarsWithBrand")]
        public async Task<IActionResult> GetLast5CarsWithBrand()
        {
            var cars = await _mediator.Send(new GetLast5CarsWithBrandQuery());
            var carsDto = cars.Select(c => new GetLast5CarsWithBrandDto()
            {
                Id = c.Id,
                ModelId = c.ModelId,
                Model = c.Model,
                BrandId = c.BrandId,
                Brand = c.Brand,
                BigImageUrl = c.BigImageUrl,
                CoverImageUrl = c.CoverImageUrl,
                FuelType = c.FuelType,
                Km = c.Km,
                Luggage = c.Luggage,
                SeatCount = c.SeatCount,
                TransmissionType = c.TransmissionType,
            });

            return Ok(carsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery] GetCarByIdQueryDto getCarByIdQueryDto)
        {
            var query = new GetCarByIdQuery()
            {
                Id = id,
                IncludeModel = getCarByIdQueryDto.IncludeModel,
                IncludeBrand = getCarByIdQueryDto.IncludeBrand
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
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCarCommand(id);
            await _mediator.Send(command);

            return Ok("Car has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarDto updateCarDto)
        {
            var updateCarCommand = new UpdateCarCommand()
            {
                Id = updateCarDto.Id,
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
