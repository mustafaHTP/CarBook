using CarBook.Application.Dtos.TestimonialDtos;
using CarBook.Application.Features.TestimonialFeatures.Commands;
using CarBook.Application.Features.TestimonialFeatures.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TestimonialsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var testimonials = await _mediator.Send(new GetTestimonialsQuery());
            var testimonialDtos = testimonials.Select(t => new GetTestimonialsDto()
            {
                Id = t.Id,
                Name = t.Name,
                Title = t.Title,
                Comment = t.Comment,
                ImageUrl = t.ImageUrl
            });

            return Ok(testimonialDtos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var testimonial = await _mediator.Send(new GetTestimonialByIdQuery() { Id = id });
            var testimonialDto = new GetTestimonialByIdDto()
            {
                Id = testimonial.Id,
                Name = testimonial.Name,
                Title = testimonial.Title,
                Comment = testimonial.Comment,
                ImageUrl = testimonial.ImageUrl
            };


            return Ok(testimonialDto);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialDto createTestimonialDto)
        {
            var command = new CreateTestimonialCommand()
            {
                Name = createTestimonialDto.Name,
                Title = createTestimonialDto.Title,
                Comment = createTestimonialDto.Comment,
                ImageUrl = createTestimonialDto.ImageUrl
            };

            await _mediator.Send(command);

            return Ok("Testimonial has been created");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateTestimonialDto updateTestimonialDto)
        {
            var command = new UpdateTestimonialCommand()
            {
                Id = id,
                Name = updateTestimonialDto.Name,
                Title = updateTestimonialDto.Title,
                Comment = updateTestimonialDto.Comment,
                ImageUrl = updateTestimonialDto.ImageUrl
            };

            await _mediator.Send(command);

            return Ok("Testimonial has been updated");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteTestimonialCommand() { Id = id };

            await _mediator.Send(command);

            return Ok("Testimonial has been deleted");
        }
    }
}
