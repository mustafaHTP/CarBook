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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll([FromQuery] GetCarsQuery getCarsQuery)
        {
            var cars = await _mediator.Send(getCarsQuery);
            var carsDto = cars.Select(c => new GetCarsDto()
            {
                Id = c.Id,
                ModelId = c.ModelId,
                Model = c.Model,
                BrandId = c.Model.BrandId,
                Brand = c.Model.Brand,
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
