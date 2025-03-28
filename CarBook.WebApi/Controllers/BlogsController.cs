﻿using CarBook.Application.Dtos.BannerDtos;
using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Features.BlogCommentFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using CarBook.WebApi.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] GetBlogsQueryDto getBlogsQueryDto)
        {
            var query = new GetBlogsQuery()
            {
                Includes = getBlogsQueryDto.Includes,
                Limit = getBlogsQueryDto.Limit,
                DescendingOrder = getBlogsQueryDto.DescendingOrder
            };
            var blogs = await _mediator.Send(query);
            var blogsDto = blogs.Select(b => new GetBlogsDto()
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                Description = b.Description,
                CoverImageUrl = b.CoverImageUrl,
                CreatedDate = b.CreatedDate,
                BlogAuthorId = b.BlogAuthorId,
                BlogAuthorName = b.BlogAuthor?.Name,
                BlogAuthorDescription = b.BlogAuthor?.Description,
                BlogAuthorImageUrl = b.BlogAuthor?.ImageUrl,
                BlogCategoryId = b.BlogCategoryId,
                BlogCategoryName = b.BlogCategory?.Name
            });

            return Ok(GenericApiResponse<IEnumerable<GetBlogsDto>>.Success(blogsDto));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Blog>))]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery] GetBlogByIdQueryDto getBlogByIdQueryDto)
        {
            var query = new GetBlogByIdQuery()
            {
                Id = id,
                Includes = getBlogByIdQueryDto.Includes
            };

            var blog = await _mediator.Send(query);
            var blogDto = new GetBlogByIdDto()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Description = blog.Description,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                BlogAuthorId = blog.BlogAuthorId,
                BlogAuthorName = blog.BlogAuthor?.Name,
                BlogAuthorDescription = blog.BlogAuthor?.Description,
                BlogAuthorImageUrl = blog.BlogAuthor?.ImageUrl,
                BlogCategoryId = blog.BlogCategoryId,
                BlogCategoryName = blog.BlogCategory?.Name
            };

            return Ok(GenericApiResponse<GetBlogByIdDto>.Success(blogDto));
        }

        [HttpGet("{id}/tags")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Blog>))]
        public async Task<IActionResult> GetAllBlogTagsById(int id)
        {
            var blogTags = await _mediator.Send(new GetBlogTagsByIdQuery() { Id = id });
            var blogTagsDto = blogTags.Select(bt => new GetBlogTagsByIdDto()
            {
                Id = bt.Id,
                Name = bt.Name
            });

            return Ok(GenericApiResponse<IEnumerable<GetBlogTagsByIdDto>>.Success(blogTagsDto));
        }

        [HttpGet("{id}/comments")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Blog>))]
        public async Task<IActionResult> GetAllBlogCommentsById(int id)
        {
            var blogComments = await _mediator.Send(new GetBlogCommentsByBlogIdQuery() { BlogId = id });
            var blogCommentsDto = blogComments.Select(bc => new GetBlogCommentsByBlogIdDto()
            {
                Id = bc.Id,
                Content = bc.Content,
                Name = bc.Name,
                CreatedDate = bc.CreatedDate,
                BlogId = bc.BlogId,
            });

            return Ok(GenericApiResponse<IEnumerable<GetBlogCommentsByBlogIdDto>>.Success(blogCommentsDto));
        }

        [HttpGet("{id}/comments/count")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Blog>))]
        public async Task<IActionResult> GetBlogCommentCountById(int id)
        {
            var result =
                await _mediator.Send(new GetBlogCommentCountByIdQuery() { Id = id });
            var resultDto = new GetBlogCommentCountByIdDto()
            {
                BlogCommentCount = result.BlogCommentCount
            };

            return Ok(GenericApiResponse<GetBlogCommentCountByIdDto>.Success(resultDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogDto createBlogDto)
        {
            var command = new CreateBlogCommand()
            {
                Title = createBlogDto.Title,
                Description = createBlogDto.Description,
                Content = createBlogDto.Content,
                CoverImageUrl = createBlogDto.CoverImageUrl,
                CreatedDate = createBlogDto.CreatedDate,
                BlogAuthorId = createBlogDto.BlogAuthorId,
                BlogCategoryId = createBlogDto.BlogCategoryId
            };
            await _mediator.Send(command);

            return Ok("Blog has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Blog>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogDto updateBlogDto)
        {
            var command = new UpdateBlogCommand()
            {
                Id = id,
                Title = updateBlogDto.Title,
                Description = updateBlogDto.Description,
                Content = updateBlogDto.Content,
                CoverImageUrl = updateBlogDto.CoverImageUrl,
                BlogAuthorId = updateBlogDto.BlogAuthorId,
                BlogCategoryId = updateBlogDto.BlogCategoryId
            };
            await _mediator.Send(command);

            return Ok("Blog has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<Blog>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCommand() { Id = id };
            await _mediator.Send(command);

            return Ok("Blog has been deleted");
        }
    }
}
