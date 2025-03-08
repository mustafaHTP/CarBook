using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Features.BlogCommentFeatures.Commands;
using CarBook.Application.Features.BlogCommentFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCommentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogCommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogComments = await _mediator.Send(new GetBlogCommentsQuery());
            var blogCommentsDto = blogComments.Select(x => new GetBlogCommentsDto()
            {
                Id = x.Id,
                BlogId = x.BlogId,
                Content = x.Content,
                Email = x.Email,
                CreatedDate = x.CreatedDate,
                Name = x.Name
            });

            return Ok(blogCommentsDto);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogComment>))]
        public async Task<IActionResult> GetById(int id)
        {
            var blogComment = await _mediator.Send(new GetBlogCommentByIdQuery() { Id = id });
            var blogCommentDto = new GetBlogCommentByIdDto()
            {
                Id = blogComment.Id,
                BlogId = blogComment.BlogId,
                Email = blogComment.Email,
                Content = blogComment.Content,
                CreatedDate = blogComment.CreatedDate,
                Name = blogComment.Name
            };

            return Ok(blogCommentDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommentDto createBlogCommentDto)
        {
            var command = new CreateBlogCommentCommand()
            {
                BlogId = createBlogCommentDto.BlogId,
                Content = createBlogCommentDto.Content,
                Email = createBlogCommentDto.Email,
                Name = createBlogCommentDto.Name,
                CreatedDate = DateTime.Now
            };
            await _mediator.Send(command);

            return Ok("BlogComment has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogComment>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogCommentDto updateBlogCommentDto)
        {
            var command = new UpdateBlogCommentCommand()
            {
                Id = id,
                BlogId = updateBlogCommentDto.BlogId,
                Content = updateBlogCommentDto.Content,
                Name = updateBlogCommentDto.Name,
                Email = updateBlogCommentDto.Email,
                CreatedDate = DateTime.Now
            };
            await _mediator.Send(command);

            return Ok("BlogComment has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogComment>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCommentCommand() { Id = id };
            await _mediator.Send(command);

            return Ok("BlogComment has been deleted");
        }
    }
}
