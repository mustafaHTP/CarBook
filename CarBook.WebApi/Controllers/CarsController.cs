using CarBook.Application.Dtos.Car;
using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Features.CarFeatures.Handlers;
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

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var cars = await _mediator.Send(new GetCarsQuery());
            var carsDto = cars.Select(c => new GetCarsDto()
            {
                Id = c.Id,
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
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCarByIdQuery(id);
            var car = await _mediator.Send(query);

            return Ok(car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand createCarCommand)
        {
            await _mediator.Send(createCarCommand);

            return Ok("Car has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCarCommand(id);
            await _mediator.Send(command);

            return Ok("Car has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarCommand updateCarCommand)
        {
            await _mediator.Send(updateCarCommand);

            return Ok("Car has been updated");
        }
    }
}
