using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Features.BlogTagFeatures.Commands;
using CarBook.Application.Features.BlogTagFeatures.Queries;
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

        [HttpGet()]
        public async Task<IActionResult> GetAll()
        {
            var blogTags = await _mediator.Send(new GetBlogTagsQuery());

            return Ok(blogTags);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogTag = await _mediator.Send(new GetBlogTagByIdQuery() { Id = id });

            return Ok(blogTag);
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

            return Ok(blogTagsDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogTagCommand createBlogTagCommand)
        {
            await _mediator.Send(createBlogTagCommand);

            return Ok("Blog Tag has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogTagCommand updateBlogTagCommand)
        {
            await _mediator.Send(updateBlogTagCommand);

            return Ok("Blog Tag has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteBlogTagCommand deleteBlogTagCommand)
        {
            await _mediator.Send(deleteBlogTagCommand);

            return Ok("Blog Tag has been deleted");
        }
    }
}
