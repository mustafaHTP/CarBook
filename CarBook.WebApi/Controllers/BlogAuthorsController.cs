using CarBook.Application.Dtos.BlogAuthorDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Features.BlogAuthorFeatures.Commands;
using CarBook.Application.Features.BlogAuthorFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAuthorsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogAuthorsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet()]
        public async Task<IActionResult> GetAll([FromQuery] GetBlogAuthorsQueryDto getBlogAuthorsQueryDto)
        {
            var query = new GetBlogAuthorsQuery() { IncludeBlogs = getBlogAuthorsQueryDto.IncludeBlogs };
            var blogAuthors = await _mediator.Send(query);
            var blogAuthorsDto = blogAuthors.Select(ba => new GetBlogAuthorsDto()
            {
                Id = ba.Id,
                Name = ba.Name,
                Description = ba.Description,
                ImageUrl = ba.ImageUrl,
                Blogs = ba.Blogs?.Select(b => new BlogLiteDto()
                {
                    Id = b.Id,
                    Title = b.Title,
                    Description = b.Description,
                    Content = b.Content,
                    CoverImageUrl = b.CoverImageUrl,
                    CreatedDate = b.CreatedDate,
                    BlogAuthorId = b.BlogAuthorId,
                    BlogCategoryId = b.BlogCategoryId
                }).ToList()
            });

            return Ok(blogAuthorsDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogAuthor = await _mediator.Send(new GetBlogAuthorByIdQuery() { Id = id });
            var blogAuthorDto = new GetBlogAuthorByIdDto()
            {
                Id = blogAuthor.Id,
                Name = blogAuthor.Name,
                Description = blogAuthor.Description,
                ImageUrl = blogAuthor.ImageUrl
            };

            return Ok(blogAuthorDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogAuthorDto createBlogAuthorDto)
        {
            var command = new CreateBlogAuthorCommand()
            {
                Name = createBlogAuthorDto.Name,
                Description = createBlogAuthorDto.Description,
                ImageUrl = createBlogAuthorDto.ImageUrl
            };
            await _mediator.Send(command);

            return Ok("BlogAuthor has been created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogAuthorDto updateBlogAuthorDto)
        {
            var command = new UpdateBlogAuthorCommand()
            {
                Id = id,
                Name = updateBlogAuthorDto.Name,
                Description = updateBlogAuthorDto.Description,
                ImageUrl = updateBlogAuthorDto.ImageUrl
            };

            await _mediator.Send(command);

            return Ok("BlogAuthor has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBlogAuthorCommand() { Id = id });

            return Ok("BlogAuthor has been deleted");
        }
    }
}
