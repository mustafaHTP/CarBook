using CarBook.Application.Dtos.BlogTagCloudDtos;
using CarBook.Application.Features.BlogTagCloudFeatures.Commands;
using CarBook.Application.Features.BlogTagCloudFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
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
            var blogTagCloudsDto = blogTagClouds.Select(x => new GetBlogTagCloudsDto()
            {
                Id = x.Id,
                BlogId = x.BlogId,
                BlogTagId = x.BlogTagId
            }).ToList();

            return Ok(blogTagCloudsDto);
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogTagCloud>))]
        public async Task<IActionResult> GetById(int id)
        {
            var blogTagCloud = await _mediator.Send(new GetBlogTagCloudByIdQuery() { Id = id });
            var blogTagCloudDto = new GetBlogTagCloudByIdDto()
            {
                Id = blogTagCloud.Id,
                BlogId = blogTagCloud.BlogId,
                BlogTagId = blogTagCloud.BlogTagId
            };

            return Ok(blogTagCloudDto);
        }

        [HttpGet("{blogId}/tags")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogTagCloud>))]
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
        public async Task<IActionResult> Create(CreateBlogTagCloudDto createBlogTagCloudDto)
        {
            var command = new CreateBlogTagCloudCommand()
            {
                BlogId = createBlogTagCloudDto.BlogId,
                BlogTagId = createBlogTagCloudDto.BlogTagId
            };

            await _mediator.Send(command);

            return Ok("Blog Tag Cloud has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogTagCloud>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateBlogTagCloudDto updateBlogTagCloudDto)
        {
            var command = new UpdateBlogTagCloudCommand
            {
                Id = id,
                BlogId = updateBlogTagCloudDto.BlogId,
                BlogTagId = updateBlogTagCloudDto.BlogTagId
            };

            await _mediator.Send(command);

            return Ok("Blog Tag Cloud has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<BlogTagCloud>))]
        public async Task<IActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteBlogTagCloudCommand() { Id = id });

            return Ok("Blog Tag Cloud has been deleted");
        }
    }
}
