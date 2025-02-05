using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Features.BlogFeatures.Handlers;
using CarBook.Application.Features.BlogFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogCategoriesController : ControllerBase
    {
        private readonly CreateBlogCategoryCommandHandler _createBlogCategoryCommandHandler;
        private readonly UpdateBlogCategoryCommandHandler _updateBlogCategoryCommandHandler;
        private readonly DeleteBlogCategoryCommandHandler _deleteBlogCategoryCommandHandler;
        private readonly GetBlogCategoriesQueryHandler _getAllBlogCategoriesQueryHandler;
        private readonly GetBlogCategoryByIdQueryHandler _getBlogCategoryByIdQueryHandler;
        private readonly IMediator _mediator;

        public BlogCategoriesController(CreateBlogCategoryCommandHandler createBlogCategoryCommandHandler,
            UpdateBlogCategoryCommandHandler updateBlogCategoryCommandHandler,
            DeleteBlogCategoryCommandHandler deleteBlogCategoryCommandHandler,
            GetBlogCategoriesQueryHandler getAllBlogCategoriesQueryHandler,
            GetBlogCategoryByIdQueryHandler getBlogCategoryByIdQueryHandler,
            IMediator mediator)
        {
            _createBlogCategoryCommandHandler = createBlogCategoryCommandHandler;
            _updateBlogCategoryCommandHandler = updateBlogCategoryCommandHandler;
            _deleteBlogCategoryCommandHandler = deleteBlogCategoryCommandHandler;
            _getAllBlogCategoriesQueryHandler = getAllBlogCategoriesQueryHandler;
            _getBlogCategoryByIdQueryHandler = getBlogCategoryByIdQueryHandler;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var blogCategories = await _mediator.Send(new GetBlogCategoriesQuery());

            return Ok(blogCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBlogCategoryByIdQuery() { Id = id };
            var blogCategory = await _mediator.Send(query);

            return Ok(blogCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCategoryCommand createBlogCategoryCommand)
        {
            await _mediator.Send(createBlogCategoryCommand);

            return Ok("BlogCategory has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCategoryCommand() { Id = id };
            await _mediator.Send(command);

            return Ok("BlogCategory has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCategoryCommand updateBlogCategoryCommand)
        {
            await _mediator.Send(updateBlogCategoryCommand);

            return Ok("BlogCategory has been updated");
        }
    }
}
