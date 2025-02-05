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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var blogAuthors = await _mediator.Send(new GetBlogAuthorsQuery());

            return Ok(blogAuthors);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogAuthor = await _mediator.Send(new GetBlogAuthorByIdQuery() { Id = id });

            return Ok(blogAuthor);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogAuthorCommand createBlogAuthorCommand)
        {
            await _mediator.Send(createBlogAuthorCommand);

            return Ok("BlogAuthor has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogAuthorCommand updateBlogAuthorCommand)
        {
            await _mediator.Send(updateBlogAuthorCommand);

            return Ok("BlogAuthor has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBlogAuthorCommand deleteBlogAuthorCommand)
        {
            await _mediator.Send(deleteBlogAuthorCommand);

            return Ok("BlogAuthor has been deleted");
        }
    }
}
