using CarBook.Application.Features.BrandFeatures.Commands;
using CarBook.Application.Features.BrandFeatures.Handlers;
using CarBook.Application.Features.BrandFeatures.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : ControllerBase
    {
        private readonly CreateBrandCommandHandler _createBrandCommandHandler;
        private readonly UpdateBrandCommandHandler _updateBrandCommandHandler;
        private readonly DeleteBrandCommandHandler _deleteBrandCommandHandler;
        private readonly GetBrandsQueryHandler _getAllBrandQueryHandler;
        private readonly GetBrandByIdQueryHandler _getBrandByIdQueryHandler;

        public BrandsController(CreateBrandCommandHandler createBrandCommandHandler,
            UpdateBrandCommandHandler updateBrandCommandHandler,
            DeleteBrandCommandHandler deleteBrandCommandHandler,
            GetBrandsQueryHandler getBrandQueryHandler,
            GetBrandByIdQueryHandler getBrandByIdQueryHandler)
        {
            _createBrandCommandHandler = createBrandCommandHandler;
            _updateBrandCommandHandler = updateBrandCommandHandler;
            _deleteBrandCommandHandler = deleteBrandCommandHandler;
            _getAllBrandQueryHandler = getBrandQueryHandler;
            _getBrandByIdQueryHandler = getBrandByIdQueryHandler;
        }

        [HttpGet]
        public async Task<IActionResult> BrandList()
        {
            var Brands = await _getAllBrandQueryHandler.Handle();

            return Ok(Brands);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetBrandByIdQuery(id);
            var Brand = await _getBrandByIdQueryHandler.Handle(query);

            return Ok(Brand);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateBrandCommand createBrandCommand)
        {
            await _createBrandCommandHandler.Handle(createBrandCommand);

            return Ok("Brand has been created");
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var command = new DeleteBrandCommand(id);
            await _deleteBrandCommandHandler.Handle(command);

            return Ok("Brand has been deleted");
        }


        [HttpPut]
        public async Task<IActionResult> Update(UpdateBrandCommand updateBrandCommand)
        {
            await _updateBrandCommandHandler.Handle(updateBrandCommand);

            return Ok("Brand has been updated");
        }
    }
}
