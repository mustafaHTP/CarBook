﻿using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Features.BlogTagFeatures.Commands;
using CarBook.Application.Features.BlogTagFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using CarBook.WebApi.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTagsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogTagsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogTags = await _mediator.Send(new GetBlogTagsQuery());
            var blogTagsDto = blogTags.Select(x => new GetBlogTagsDto()
            {
                Id = x.Id,
                Name = x.Name
            });

            return Ok(GenericApiResponse<IEnumerable<GetBlogTagsDto>>.Success(blogTagsDto));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogTag>))]
        public async Task<IActionResult> GetById(int id)
        {
            var blogTag = await _mediator.Send(new GetBlogTagByIdQuery() { Id = id });
            var blogTagDto = new GetBlogTagByIdDto()
            {
                Id = blogTag.Id,
                Name = blogTag.Name
            };

            return Ok(GenericApiResponse<GetBlogTagByIdDto>.Success(blogTagDto));
        }

        [HttpGet("last/{count}")]
        public async Task<IActionResult> GetLastN(int count)
        {
            var blogTags = await _mediator.Send(new GetLastNBlogTagsQuery() { Count = count });
            var blogTagsDto = blogTags.Select(x => new GetLastNBlogTagsDto()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return Ok(GenericApiResponse<IEnumerable<GetLastNBlogTagsDto>>.Success(blogTagsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogTagDto createBlogTagDto)
        {
            var command = new CreateBlogTagCommand
            {
                Name = createBlogTagDto.Name
            };

            await _mediator.Send(command);

            return Ok("Blog Tag has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogTag>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogTagDto updateBlogTagDto)
        {
            var command = new UpdateBlogTagCommand
            {
                Id = id,
                Name = updateBlogTagDto.Name
            };

            await _mediator.Send(command);

            return Ok("Blog Tag has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogTag>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogTagCommand() { Id = id };

            await _mediator.Send(command);

            return Ok("Blog Tag has been deleted");
        }
    }
}
