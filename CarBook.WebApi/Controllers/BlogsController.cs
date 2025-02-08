using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Features.BlogCommentFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogTagFeatures.Commands;
using CarBook.Application.Features.BlogTagFeatures.Queries;
using CarBook.Application.Features.ServiceFeatures.Commands;
using CarBook.Application.Features.ServiceFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> GetAll()
        {
            var blogs = await _mediator.Send(new GetBlogsQuery());

            return Ok(blogs);
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
        public async Task<IActionResult> GetById(int id)
        {
            var blog = await _mediator.Send(new GetBlogByIdQuery() { Id = id });

            return Ok(blog);
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetAllBlogCommentsById(int id)
        {
            var blogComments = await _mediator.Send(new GetBlogCommentsByBlogIdQuery() { BlogId = id});
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
        public async Task<IActionResult> Create(CreateBlogCommand createBlogCommand)
        {
            await _mediator.Send(createBlogCommand);

            return Ok("Blog has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCommand updateBlogCommand)
        {
            await _mediator.Send(updateBlogCommand);

            return Ok("Blog has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBlogCommand deleteBlogCommand)
        {
            await _mediator.Send(deleteBlogCommand);

            return Ok("Blog has been deleted");
        }
    }
}
