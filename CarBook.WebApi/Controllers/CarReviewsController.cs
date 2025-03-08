using CarBook.Application.Dtos.CarReviewDtos;
using CarBook.Application.Features.CarReviewFeatures.Commands;
using CarBook.Application.Features.CarReviewFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<CarReview>))]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetCarReviewByIdQuery
            {
                Id = id
            };

            var result = await _mediator.Send(query);
            var resultDto = new GetCarReviewByIdDto
            {
                Id = result.Id,
                CarId = result.CarId,
                CustomerId = result.CustomerId,
                Review = result.Review,
                ReviewDate = result.ReviewDate,
                RatingStarCount = result.RatingStarCount
            };

            return Ok(resultDto);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var query = new GetCarReviewsQuery();
            var result = await _mediator.Send(query);
            var resultDto = result.Select(x => new GetCarReviewByIdDto
            {
                Id = x.Id,
                CarId = x.CarId,
                CustomerId = x.CustomerId,
                Review = x.Review,
                ReviewDate = x.ReviewDate,
                RatingStarCount = x.RatingStarCount
            });

            return Ok(resultDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarReviewDto createCarReviewDto)
        {
            var command = new CreateCarReviewCommand
            {
                CarId = createCarReviewDto.CarId,
                CustomerId = createCarReviewDto.CustomerId,
                Review = createCarReviewDto.Review,
                ReviewDate = createCarReviewDto.ReviewDate,
                RatingStarCount = createCarReviewDto.RatingStarCount
            };

            await _mediator.Send(command);

            return CreatedAtAction(
                actionName: nameof(CarsController.GetCarReviewsByCarId),
                controllerName: "Cars",
                routeValues: new { carId = command.CarId },
                command);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<CarReview>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateCarReviewDto updateCarReviewDto)
        {
            var command = new UpdateCarReviewCommand
            {
                Id = id,
                ReviewDate = updateCarReviewDto.ReviewDate,
                Review = updateCarReviewDto.Review,
                RatingStarCount = updateCarReviewDto.RatingStarCount
            };

            await _mediator.Send(command);

            return Ok("Car Review has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<CarReview>))]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var command = new DeleteCarReviewCommand
            {
                Id = id
            };

            await _mediator.Send(command);

            return Ok("Car Review has been deleted");
        }
    }
}
