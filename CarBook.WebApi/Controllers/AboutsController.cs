using CarBook.Application.Features.AboutFeatures.Commands;
using CarBook.Application.Features.AboutFeatures.Handlers;
using CarBook.Application.Features.AboutFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly CreateAboutCommandHandler _createAboutCommandHandler;
        private readonly UpdateAboutCommandHandler _updateAboutCommandHandler;
        private readonly DeleteAboutCommandHandler _deleteAboutCommandHandler;
        private readonly GetAboutsQueryHandler _getAllAboutQueryHandler;
        private readonly GetAboutByIdQueryHandler _getAboutByIdQueryHandler;

        public AboutsController(CreateAboutCommandHandler createAboutCommandHandler, 
            UpdateAboutCommandHandler updateAboutCommandHandler, 
            DeleteAboutCommandHandler deleteAboutCommandHandler, 
            GetAboutsQueryHandler getAboutQueryHandler, 
            GetAboutByIdQueryHandler getAboutByIdQueryHandler)
        {
            _createAboutCommandHandler = createAboutCommandHandler;
            _updateAboutCommandHandler = updateAboutCommandHandler;
            _deleteAboutCommandHandler = deleteAboutCommandHandler;
            _getAllAboutQueryHandler = getAboutQueryHandler;
            _getAboutByIdQueryHandler = getAboutByIdQueryHandler;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> AboutList()
        {
            var abouts = await _getAllAboutQueryHandler.Handle();

            return Ok(abouts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetAboutByIdQuery(id);
            var about = await _getAboutByIdQueryHandler.Handle(query);

            return Ok(about);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateAboutCommand createAboutCommand)
        {
            await _createAboutCommandHandler.Handle(createAboutCommand);

            return Ok("About has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteAboutCommand(id);
            await _deleteAboutCommandHandler.Handle(command);

            return Ok("About has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateAboutCommand updateAboutCommand)
        {
            await _updateAboutCommandHandler.Handle(updateAboutCommand);

            return Ok("About has been updated");
        }
    }
}
