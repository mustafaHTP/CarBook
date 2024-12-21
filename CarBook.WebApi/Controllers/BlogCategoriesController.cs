using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Features.BlogFeatures.Handlers;
using CarBook.Application.Features.BlogFeatures.Queries;
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
        private readonly GetAllBlogCategoriesQueryHandler _getAllBlogCategoriesQueryHandler;
        private readonly GetBlogCategoryByIdQueryHandler _getBlogCategoryByIdQueryHandler;

        public BlogCategoriesController(CreateBlogCategoryCommandHandler createBlogCategoryCommandHandler, 
            UpdateBlogCategoryCommandHandler updateBlogCategoryCommandHandler, 
            DeleteBlogCategoryCommandHandler deleteBlogCategoryCommandHandler, 
            GetAllBlogCategoriesQueryHandler getAllBlogCategoriesQueryHandler, 
            GetBlogCategoryByIdQueryHandler getBlogCategoryByIdQueryHandler)
        {
            _createBlogCategoryCommandHandler = createBlogCategoryCommandHandler;
            _updateBlogCategoryCommandHandler = updateBlogCategoryCommandHandler;
            _deleteBlogCategoryCommandHandler = deleteBlogCategoryCommandHandler;
            _getAllBlogCategoriesQueryHandler = getAllBlogCategoriesQueryHandler;
            _getBlogCategoryByIdQueryHandler = getBlogCategoryByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BlogCategoryList()
        {
            var blogCategories = await _getAllBlogCategoriesQueryHandler.Handle();

            return Ok(blogCategories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBlogCategoryByIdQuery(id);
            var blogCategory = await _getBlogCategoryByIdQueryHandler.Handle(query);

            return Ok(blogCategory);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBlogCategoryCommand createBlogCategoryCommand)
        {
            await _createBlogCategoryCommandHandler.Handle(createBlogCategoryCommand);

            return Ok("BlogCategory has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBlogCategoryCommand(id);
            await _deleteBlogCategoryCommandHandler.Handle(command);

            return Ok("BlogCategory has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBlogCategoryCommand updateBlogCategoryCommand)
        {
            await _updateBlogCategoryCommandHandler.Handle(updateBlogCategoryCommand);

            return Ok("BlogCategory has been updated");
        }
    }
}
