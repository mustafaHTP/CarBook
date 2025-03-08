using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Features.BlogCategoryFeatures.Commands;
using CarBook.Application.Features.BlogCategoryFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogCategories = await _mediator.Send(new GetBlogCategoriesQuery());
            var blogCategoriesDto = blogCategories.Select(blogCategory => new GetBlogCategoriesDto
            {
                Id = blogCategory.Id,
                Name = blogCategory.Name
            });

            return Ok(blogCategoriesDto);
        }

        [HttpGet("{id}/blogs")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogCategory>))]
        public async Task<IActionResult> GetAllBlogsById([FromRoute ]int id, [FromQuery] GetBlogsByBlogCategoryIdQueryDto getBlogsByBlogCategoryIdQueryDto)
        {
            var query = new GetBlogsByBlogCategoryIdQuery
            {
                BlogCategoryId = id,
                Includes = getBlogsByBlogCategoryIdQueryDto.Includes
            };

            var blogs = await _mediator.Send(query);
            var blogsDto = blogs.Select(blog => new GetBlogsByBlogCategoryIdDto
            {
                Id = blog.Id,
                Title = blog.Title,
                Description = blog.Description,
                BlogCategoryId = blog.BlogCategoryId,
                BlogCategoryName = blog.BlogCategory.Name,
                BlogAuthorId = blog.BlogAuthorId,
                BlogAuthorName = blog.BlogAuthor.Name,
                BlogAuthorDescription = blog.BlogAuthor.Description,
                BlogAuthorImageUrl = blog.BlogAuthor.ImageUrl,
                Content = blog.Content,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate
            });

            return Ok(blogsDto);
        }

        [HttpGet("{id}/blogs/count")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogCategory>))]
        public async Task<IActionResult> GetBlogsCountById(int id)
        {
            var query = new GetBlogsCountByBlogCategoryIdQuery() { BlogCategoryId = id };
            var blogCount = await _mediator.Send(query);
            var blogCountDto = new GetBlogsCountByIdDto
            {
                Count = blogCount.Count
            };

            return Ok(blogCountDto);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogCategory>))]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBlogCategoryByIdQuery() { Id = id };
            var blogCategory = await _mediator.Send(query);
            var blogCategoryDto = new GetBlogCategoryByIdDto
            {
                Id = blogCategory.Id,
                Name = blogCategory.Name
            };

            return Ok(blogCategoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCategoryDto createBlogCategoryDto)
        {
            var command = new CreateBlogCategoryCommand
            {
                Name = createBlogCategoryDto.Name
            };
            await _mediator.Send(command);

            return Ok("BlogCategory has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogCategory>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogCategoryCommand updateBlogCategoryCommand)
        {
            var command = new UpdateBlogCategoryCommand
            {
                Id = id,
                Name = updateBlogCategoryCommand.Name
            };
            await _mediator.Send(command);

            return Ok("BlogCategory has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogCategory>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCategoryCommand() { Id = id };
            await _mediator.Send(command);

            return Ok("BlogCategory has been deleted");
        }
    }
}
