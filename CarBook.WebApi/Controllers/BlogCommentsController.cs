using CarBook.Application.Features.BlogCommentFeatures.Commands;
using CarBook.Application.Features.BlogCommentFeatures.Queries;
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

            return Ok(blogComments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogComment = await _mediator.Send(new GetBlogCommentByIdQuery() { Id = id });

            return Ok(blogComment);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCommentCommand createBlogCommentCommand)
        {
            await _mediator.Send(createBlogCommentCommand);

            return Ok("BlogComment has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCommentCommand updateBlogCommentCommand)
        {
            await _mediator.Send(updateBlogCommentCommand);

            return Ok("BlogComment has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBlogCommentCommand deleteBlogCommentCommand)
        {
            await _mediator.Send(deleteBlogCommentCommand);

            return Ok("BlogComment has been deleted");
        }
    }
}
