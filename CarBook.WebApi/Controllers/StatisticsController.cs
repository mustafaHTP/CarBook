﻿using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Dtos.StatisticsDtos;
using CarBook.Application.Features.StatisticsFeatures.Queries;
using CarBook.WebApi.Responses;
using MediatR;
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
            var result = await _mediator.Send(new GetCarCountQuery());
            var resultDto = new GetCarCountDto
            {
                CarCount = result.CarCount
            };

            return Ok(GenericApiResponse<GetCarCountDto>.Success(resultDto));
        }

        [HttpGet("car/countByFuelType")]
        public async Task<IActionResult> GetCarCountByFuelTypeAsync([FromQuery] GetCarCountByFuelTypeQueryDto getCarCountByFuelTypeQueryDto)
        {
            var query = new GetCarCountByFuelTypeQuery
            {
                FuelTypes = getCarCountByFuelTypeQueryDto.FuelTypes
            };
            var result = await _mediator.Send(query);
            var resultDto = new GetCarCountByFuelTypeDto
            {
                CarCount = result.CarCount
            };

            return Ok(GenericApiResponse<GetCarCountByFuelTypeDto>.Success(resultDto));
        }

        [HttpGet("car/countByTransmissionType")]
        public async Task<IActionResult> GetCarCountByTransmissionTypeAsync([FromQuery] GetCarCountByTransmissionTypeQueryDto getCarCountByTransmissionTypeQueryDto)
        {
            var query = new GetCarCountByTransmissionTypeQuery
            {
                TransmissionTypes = getCarCountByTransmissionTypeQueryDto.TransmissionTypes
            };
            var result = await _mediator.Send(query);
            var resultDto = new GetCarCountByTransmissionTypeDto
            {
                CarCount = result.CarCount
            };

            return Ok(GenericApiResponse<GetCarCountByTransmissionTypeDto>.Success(resultDto));
        }

        [HttpGet("car/{carId}/carReviews/count")]
        public async Task<IActionResult> GetCarReviewsCountByCarId(int carId)
        {
            var query = new GetCarReviewCountByCarIdQuery
            {
                CarId = carId
            };
            var result = await _mediator.Send(query);
            var resultDto = new GetCarReviewsCountByCarIdDto
            {
                CarReviewCount = result.CarReviewCount
            };

            return Ok(GenericApiResponse<GetCarReviewsCountByCarIdDto>.Success(resultDto));
        }

        [HttpGet("blogAuthor/count")]
        public async Task<IActionResult> GetBlogAuthorCountAsync()
        {
            var result = await _mediator.Send(new GetBlogAuthorCountQuery());
            var resultDto = new GetBlogAuthorCountDto
            {
                BlogAuthorCount = result.BlogAuthorCount
            };

            return Ok(GenericApiResponse<GetBlogAuthorCountDto>.Success(resultDto));
        }

        [HttpGet("location/count")]
        public async Task<IActionResult> GetLocationCountAsync()
        {
            var result = await _mediator.Send(new GetLocationCountQuery());
            var resultDto = new GetLocationCountDto
            {
                LocationCount = result.LocationCount
            };

            return Ok(GenericApiResponse<GetLocationCountDto>.Success(resultDto));
        }

        [HttpGet("location/car/count")]
        public async Task<IActionResult> GetLocationCarCountAsync()
        {
            var result = await _mediator.Send(new GetLocationCarCountQuery());
            var resultDto = result.Select(l => new GetLocationCarCountDto
            {
                LocationName = l.LocationName,
                CarCount = l.CarCount
            });
            return Ok(GenericApiResponse<IEnumerable<GetLocationCarCountDto>>.Success(resultDto));
        }

        [HttpGet("blog/count")]
        public async Task<IActionResult> GetBlogCountAsync()
        {
            var result = await _mediator.Send(new GetBlogCountQuery());
            var resultDto = new GetBlogCountDto
            {
                BlogCount = result.BlogCount
            };

            return Ok(GenericApiResponse<GetBlogCountDto>.Success(resultDto));
        }

        [HttpGet("blog/{id}/comments/count")]
        public async Task<IActionResult> GetBlogCommentCountByIdAsync(int id)
        {
            var query = new GetBlogCommentCountByBlogIdQuery
            {
                BlogId = id
            };
            var result = await _mediator.Send(query);
            var resultDto = new GetBlogCommentCountByBlogIdDto
            {
                BlogCommentCount = result.BlogCommentCount
            };

            return Ok(GenericApiResponse<GetBlogCommentCountByBlogIdDto>.Success(resultDto));
        }

        [HttpGet("blog/hasMaxCommentCount")]
        public async Task<IActionResult> GetBlogHasMaxCommentCountAsync()
        {
            var result = await _mediator.Send(new GetBlogHasMaxCommentCountQuery());
            var resultDto = new GetBlogHasMaxCommentCountDto
            {
                BlogTitle = result.BlogTitle,
                CommentCount = result.CommentCount
            };

            return Ok(GenericApiResponse<GetBlogHasMaxCommentCountDto>.Success(resultDto));
        }

        [HttpGet("brand/count")]
        public async Task<IActionResult> GetBrandCountAsync()
        {
            var result = await _mediator.Send(new GetBrandCountQuery());
            var resultDto = new GetBrandCountDto
            {
                BrandCount = result.BrandCount
            };

            return Ok(GenericApiResponse<GetBrandCountDto>.Success(resultDto));
        }

        [HttpGet("brand/car/count")]
        public async Task<IActionResult> GetBrandCarCountAsync()
        {
            var result = await _mediator.Send(new GetBrandsCarCountQuery());
            var resultDto = result.Select(b => new GetBrandsCarCountDto
            {
                BrandName = b.BrandName,
                CarCount = b.CarCount
            });

            return Ok(GenericApiResponse<IEnumerable<GetBrandsCarCountDto>>.Success(resultDto));
        }

        [HttpGet("brand/hasMaxModelCount")]
        public async Task<IActionResult> GetBrandHasMaxModelCountAsync()
        {
            var result = await _mediator.Send(new GetBrandHasMaxModelCountQuery());
            var resultDto = new GetBrandHasMaxModelCountDto
            {
                BrandName = result.BrandName,
                ModelCount = result.ModelCount
            };

            return Ok(GenericApiResponse<GetBrandHasMaxModelCountDto>.Success(resultDto));
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
            var resultDto = new GetAverageCarRentalPriceDto
            {
                AveragePrice = result.AveragePrice
            };

            return Ok(GenericApiResponse<GetAverageCarRentalPriceDto>.Success(resultDto));
        }
    }
}
