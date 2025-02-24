using CarBook.Application.Dtos.CarDtos;
using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Features.CarFeatures.Queries;
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
