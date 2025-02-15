using CarBook.Application.Dtos.BannerDtos;
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
        public async Task<IActionResult> GetAll()
        {
            var banners = await _mediator.Send(new GetBannersQuery());
            var bannersDto = banners.Select(banner => new GetBannersDto
            {
                Id = banner.Id,
                Title = banner.Title,
                Description = banner.Description,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl
            }).ToList();

            return Ok(bannersDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBannerByIdQuery(id);
            var banner = await _mediator.Send(query);
            var bannerDto = new GetBannersDto
            {
                Id = banner.Id,
                Title = banner.Title,
                Description = banner.Description,
                VideoDescription = banner.VideoDescription,
                VideoUrl = banner.VideoUrl
            };

            return Ok(bannerDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBannerDto createBannerDto)
        {
            var createBannerCommand = new CreateBannerCommand
            {
                Title = createBannerDto.Title,
                Description = createBannerDto.Description,
                VideoDescription = createBannerDto.VideoDescription,
                VideoUrl = createBannerDto.VideoUrl
            };
            await _mediator.Send(createBannerCommand);

            return Ok("Banner has been created");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBannerCommand(id);
            await _mediator.Send(command);

            return Ok("Banner has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBannerDto updateBannerDto)
        {
            var updateBannerCommand = new UpdateBannerCommand
            {
                Id = updateBannerDto.Id,
                Title = updateBannerDto.Title,
                Description = updateBannerDto.Description,
                VideoDescription = updateBannerDto.VideoDescription,
                VideoUrl = updateBannerDto.VideoUrl
            };
            await _mediator.Send(updateBannerCommand);

            return Ok("Banner has been updated");
        }
    }
}
