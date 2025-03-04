using CarBook.Application.Dtos.BlogCategoryDtos;
using CarBook.Application.Features.BlogCategoryFeatures.Commands;
using CarBook.Application.Features.BlogCategoryFeatures.Queries;
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

        [HttpGet("{id}")]
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
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCategoryCommand() { Id = id };
            await _mediator.Send(command);

            return Ok("BlogCategory has been deleted");
        }
    }
}
