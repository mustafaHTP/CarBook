using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Features.BlogCommentFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Features.BlogFeatures.Queries;
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
            //Parse includes query string to list
            var includes = getBlogsQueryDto.Includes?.Split(',').ToList();
            var query = new GetBlogsQuery()
            {
                Includes = includes ?? []
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

            return Ok(blogsDto);
        }

        [HttpGet("Last3Blogs")]
        public async Task<IActionResult> GetLast3Blogs()
        {
            var blogs = await _mediator.Send(new GetLast3BlogsWithAuthorAndCategoryQuery());

            return Ok(blogs);
        }

        [HttpGet("WithAuthorAndCategory")]
        public async Task<IActionResult> GetAllWithAuthorAndCategory()
        {
            var blogs = await _mediator.Send(new GetBlogsWithAuthorAndCategoryQuery());
            var blogsDto = blogs.Select(b => new GetBlogsWithAuthorAndCategoryDto()
            {
                Id = b.Id,
                Title = b.Title,
                Content = b.Content,
                Description = b.Description,
                CoverImageUrl = b.CoverImageUrl,
                CreatedDate = b.CreatedDate,
                BlogAuthorId = b.BlogAuthorId,
                BlogAuthorName = b.BlogAuthorName,
                BlogCategoryId = b.BlogCategoryId,
                BlogCategoryName = b.BlogCategoryName
            });

            return Ok(blogsDto);
        }

        [HttpGet("WithAuthor/{id}")]
        public async Task<IActionResult> GetByIdWithAuthor(int id)
        {
            var blog = await _mediator.Send(new GetBlogByIdWithAuthorQuery() { Id = id });
            var blogDto = new GetBlogByIdWithAuthorDto()
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Description = blog.Description,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                BlogAuthorId = blog.BlogAuthorId,
                BlogAuthorName = blog.BlogAuthorName,
                BlogAuthorDescription = blog.BlogAuthorDescription,
                BlogAuthorImageUrl = blog.BlogAuthorImageUrl
            };

            return Ok(blogDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id, [FromQuery] GetBlogByIdQueryDto getBlogByIdQueryDto)
        {
            // Parse includes query string to list
            var includes = getBlogByIdQueryDto.Includes?.Split(',').ToList();
            var query = new GetBlogByIdQuery()
            {
                Id = id,
                Includes = includes ?? []
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

            return Ok(blogDto);
        }

        [HttpGet("{id}/comments")]
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

            return Ok(blogCommentsDto);
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
        public async Task<IActionResult> Update([FromRoute]int id, [FromBody] UpdateBlogDto updateBlogDto)
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
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCommand() { Id = id };
            await _mediator.Send(command);

            return Ok("Blog has been deleted");
        }
    }
}
