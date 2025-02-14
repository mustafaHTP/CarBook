using CarBook.Application.Dtos.BlogTagCloudDtos;
using CarBook.Application.Features.BlogTagCloudFeatures.Commands;
using CarBook.Application.Features.BlogTagCloudFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogTagCloudsController : ControllerBase
    {
        private IMediator _mediator;

        public BlogTagCloudsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogTagClouds = await _mediator.Send(new GetBlogTagCloudsQuery());

            return Ok(blogTagClouds);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var blogTagCloud = await _mediator.Send(new GetBlogTagCloudByIdQuery() { Id = id });

            return Ok(blogTagCloud);
        }

        [HttpGet("{blogId}/tags")]
        public async Task<IActionResult> GetBlogTagsByBlogId(int blogId)
        {
            var query = new GetBlogTagCloudByBlogIdWithBlogTagQuery { BlogId = blogId };
            var result = await _mediator.Send(query);

            var resultDto = result.Select(x => new GetBlogTagsByBlogIdDto()
            {
                Id = x.Id,
                BlogId = x.BlogId,
                BlogTag = x.BlogTag,
                BlogTagId = x.BlogTagId
            }).ToList();

            return Ok(resultDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogTagCloudCommand createBlogTagCloudCommand)
        {
            await _mediator.Send(createBlogTagCloudCommand);

            return Ok("Blog Tag Cloud has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogTagCloudCommand updateBlogTagCloudCommand)
        {
            await _mediator.Send(updateBlogTagCloudCommand);

            return Ok("Blog Tag Cloud has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBlogTagCloudCommand() { Id = id });

            return Ok("Blog Tag Cloud has been deleted");
        }
    }
}
