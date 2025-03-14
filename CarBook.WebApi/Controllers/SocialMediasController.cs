﻿using CarBook.Application.Dtos.BlogTagDtos;
using CarBook.Application.Dtos.SocialMediaDtos;
using CarBook.Application.Features.SocialMediaFeatures.Commands;
using CarBook.Application.Features.SocialMediaFeatures.Queries;
using CarBook.Domain.Entities;
using CarBook.WebApi.Filters;
using CarBook.WebApi.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SocialMediasController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SocialMediasController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var socialMedias = await _mediator.Send(new GetSocialMediasQuery());
            var socialMediasDto = socialMedias.Select(socialMedia => new GetSocialMediasDto
            {
                Id = socialMedia.Id,
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Icon = socialMedia.Icon
            });

            return Ok(GenericApiResponse<IEnumerable<GetSocialMediasDto>>.Success(socialMediasDto));
        }

        [HttpGet("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<SocialMedia>))]
        public async Task<IActionResult> GetById(int id)
        {
            var socialMedia = await _mediator.Send(new GetSocialMediaByIdQuery() { Id = id });
            var socialMediaDto = new GetSocialMediaByIdDto
            {
                Id = socialMedia.Id,
                Name = socialMedia.Name,
                Url = socialMedia.Url,
                Icon = socialMedia.Icon
            };

            return Ok(GenericApiResponse<GetSocialMediaByIdDto>.Success(socialMediaDto));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSocialMediaDto createSocialMediaDto)
        {
            var command = new CreateSocialMediaCommand
            {
                Name = createSocialMediaDto.Name,
                Url = createSocialMediaDto.Url,
                Icon = createSocialMediaDto.Icon
            };

            await _mediator.Send(command);

            return Ok("Socia lMedia has been created");
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<SocialMedia>))]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateSocialMediaDto updateSocialMediaDto)
        {
            var command = new UpdateSocialMediaCommand
            {
                Id = id,
                Name = updateSocialMediaDto.Name,
                Url = updateSocialMediaDto.Url,
                Icon = updateSocialMediaDto.Icon
            };

            await _mediator.Send(command);

            return Ok("Social Media has been updated");
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(NotFoundFilterAttribute<SocialMedia>))]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteSocialMediaCommand { Id = id };

            await _mediator.Send(command);

            return Ok("Social Media has been deleted");
        }
    }
}
