using CarBook.Application.Features.CarFeatures.Commands;
using CarBook.Application.Features.CarFeatures.Handlers;
using CarBook.Application.Features.CarFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly CreateCarCommandHandler _createCarCommandHandler;
        private readonly UpdateCarCommandHandler _updateCarCommandHandler;
        private readonly DeleteCarCommandHandler _deleteCarCommandHandler;
        private readonly GetAllCarQueryHandler _getAllCarQueryHandler;
        private readonly GetCarByIdQueryHandler _getCarByIdQueryHandler;
        private readonly GetAllCarsWithBrandQueryHandler _getAllCarsWithBrandQueryHandler;

        public CarsController(CreateCarCommandHandler createCarCommandHandler,
            UpdateCarCommandHandler updateCarCommandHandler,
            DeleteCarCommandHandler deleteCarCommandHandler,
            GetAllCarQueryHandler getAllCarQueryHandler,
            GetCarByIdQueryHandler getCarByIdQueryHandler,
            GetAllCarsWithBrandQueryHandler getAllCarsWithBrandQueryHandler)
        {
            _createCarCommandHandler = createCarCommandHandler;
            _updateCarCommandHandler = updateCarCommandHandler;
            _deleteCarCommandHandler = deleteCarCommandHandler;
            _getAllCarQueryHandler = getAllCarQueryHandler;
            _getCarByIdQueryHandler = getCarByIdQueryHandler;
            _getAllCarsWithBrandQueryHandler = getAllCarsWithBrandQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> CarList()
        {
            var cars = await _getAllCarQueryHandler.Handle();

            return Ok(cars);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCarByIdQuery(id);
            var car = await _getCarByIdQueryHandler.Handle(query);

            return Ok(car);
        }

        [HttpGet("GetAllWithBrand")]
        public  IActionResult GetAllWithBrand()
        {
            var cars = _getAllCarsWithBrandQueryHandler.Handle();

            return Ok(cars);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarCommand createCarCommand)
        {
            await _createCarCommandHandler.Handle(createCarCommand);

            return Ok("Car has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteCarCommand(id);
            await _deleteCarCommandHandler.Handle(command);

            return Ok("Car has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateCarCommand updateCarCommand)
        {
            await _updateCarCommandHandler.Handle(updateCarCommand);

            return Ok("Car has been updated");
        }
    }
}
