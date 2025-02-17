using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Application.Features.StatisticsFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("car/count")]
        public async Task<IActionResult> GetCarCountAsync()
        {
            var carCount = await _mediator.Send(new GetCarCountQuery());

            return Ok(carCount);
        }

        [HttpGet("car/countByFuelType")]
        public async Task<IActionResult> GetCarCountByFuelTypeAsync([FromQuery] GetCarCountByFuelTypeQueryDto getCarCountByFuelTypeQueryDto)
        {
            var query = new GetCarCountByFuelTypeQuery
            {
                FuelTypes = getCarCountByFuelTypeQueryDto.FuelTypes
            };
            var carCount = await _mediator.Send(query);

            return Ok(carCount);
        }

        [HttpGet("car/countByTransmissionType")]
        public async Task<IActionResult> GetCarCountByTransmissionTypeAsync([FromQuery] GetCarCountByTransmissionTypeQueryDto getCarCountByTransmissionTypeQueryDto)
        {
            var query = new GetCarCountByTransmissionTypeQuery
            {
                TransmissionTypes = getCarCountByTransmissionTypeQueryDto.TransmissionTypes
            };
            var carCount = await _mediator.Send(query);

            return Ok(carCount);
        }

        [HttpGet("blogAuthor/count")]
        public async Task<IActionResult> GetBlogAuthorCountAsync()
        {
            var blogAuthorCount = await _mediator.Send(new GetBlogAuthorCountQuery());

            return Ok(blogAuthorCount);
        }

        [HttpGet("location/count")]
        public async Task<IActionResult> GetLocationCountAsync()
        {
            var locationCount = await _mediator.Send(new GetLocationCountQuery());

            return Ok(locationCount);
        }

        [HttpGet("blog/count")]
        public async Task<IActionResult> GetBlogCountAsync()
        {
            var blogCount = await _mediator.Send(new GetBlogCountQuery());

            return Ok(blogCount);
        }

        [HttpGet("blog/hasMaxCommentCount")]
        public async Task<IActionResult> GetBlogHasMaxCommentCountAsync()
        {
            var blog = await _mediator.Send(new GetBlogHasMaxCommentCountQuery());

            return Ok(blog);
        }

        [HttpGet("brand/count")]
        public async Task<IActionResult> GetBrandCountAsync()
        {
            var brandCount = await _mediator.Send(new GetBrandCountQuery());

            return Ok(brandCount);
        }

        [HttpGet("brand/hasMaxModelCount")]
        public async Task<IActionResult> GetBrandHasMaxModelCountAsync()
        {
            var brand = await _mediator.Send(new GetBrandHasMaxModelCountQuery());

            return Ok(brand);
        }

        [HttpGet("carRentalPrice/avg")]
        public async Task<IActionResult> GetAverageCarRentalPriceAsync([FromQuery] GetAverageCarRentalPriceQueryDto getAverageCarRentalPriceQueryDto)
        {
            var rentalPeriods = getAverageCarRentalPriceQueryDto.RentalPeriods?.Split(',');
            var query = new GetAverageCarRentalPriceQuery
            {
                RentalPeriods = rentalPeriods ?? []
            };

            var result = await _mediator.Send(query);

            return Ok(result);
        }
    }
}
