using CarBook.Application.Features.BannerFeatures.Commands;
using CarBook.Application.Features.BannerFeatures.Handlers;
using CarBook.Application.Features.BannerFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly CreateBannerCommandHandler _createBannerCommandHandler;
        private readonly UpdateBannerCommandHandler _updateBannerCommandHandler;
        private readonly DeleteBannerCommandHandler _deleteBannerCommandHandler;
        private readonly GetAllBannerQueryHandler _getAllBannerQueryHandler;
        private readonly GetBannerByIdQueryHandler _getBannerByIdQueryHandler;

        public BannersController(CreateBannerCommandHandler createBannerCommandHandler, 
            UpdateBannerCommandHandler updateBannerCommandHandler, 
            DeleteBannerCommandHandler deleteBannerCommandHandler, 
            GetAllBannerQueryHandler getBannerQueryHandler, 
            GetBannerByIdQueryHandler getBannerByIdQueryHandler)
        {
            _createBannerCommandHandler = createBannerCommandHandler;
            _updateBannerCommandHandler = updateBannerCommandHandler;
            _deleteBannerCommandHandler = deleteBannerCommandHandler;
            _getAllBannerQueryHandler = getBannerQueryHandler;
            _getBannerByIdQueryHandler = getBannerByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var banners = await _getAllBannerQueryHandler.Handle();

            return Ok(banners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBannerByIdQuery(id);
            var about = await _getBannerByIdQueryHandler.Handle(query);

            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerCommand createBannerCommand)
        {
            await _createBannerCommandHandler.Handle(createBannerCommand);

            return Ok("Banner has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBannerCommand(id);
            await _deleteBannerCommandHandler.Handle(command);

            return Ok("Banner has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerCommand updateBannerCommand)
        {
            await _updateBannerCommandHandler.Handle(updateBannerCommand);

            return Ok("Banner has been updated");
        }
    }
}
