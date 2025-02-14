using CarBook.Application.Features.BannerFeatures.Commands;
using CarBook.Application.Features.BannerFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BannersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BannersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> BannerList()
        {
            var banners = await _mediator.Send(new GetBannersQuery());

            return Ok(banners);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBannerByIdQuery(id);
            var about = await _mediator.Send(query);

            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerCommand createBannerCommand)
        {
            await _mediator.Send(createBannerCommand);

            return Ok("Banner has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBannerCommand(id);
            await _mediator.Send(command);

            return Ok("Banner has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerCommand updateBannerCommand)
        {
            await _mediator.Send(updateBannerCommand);

            return Ok("Banner has been updated");
        }
    }
}
