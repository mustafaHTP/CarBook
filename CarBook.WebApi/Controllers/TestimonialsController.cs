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

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var locations = await _mediator.Send(new GetTestimonialsQuery());

            return Ok(locations);
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var testimonial = await _mediator.Send(new GetTestimonialByIdQuery() { Id = id });

            return Ok(testimonial);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateTestimonialCommand createTestimonialCommand)
        {
            await _mediator.Send(createTestimonialCommand);

            return Ok("Testimonial has been created");
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateTestimonialCommand updateTestimonialCommand)
        {
            await _mediator.Send(updateTestimonialCommand);

            return Ok("Testimonial has been updated");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(DeleteTestimonialCommand deleteTestimonialCommand)
        {
            await _mediator.Send(deleteTestimonialCommand);

            return Ok("Testimonial has been deleted");
        }
    }
}
