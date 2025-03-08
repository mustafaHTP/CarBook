using CarBook.Application.Exceptions;
using CarBook.Application.Features.AboutFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Handlers
{
    public class UpdateAboutCommandHandler : IRequestHandler<UpdateAboutCommand>
    {
        private readonly IRepository<About> _repository;

        public UpdateAboutCommandHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAboutCommand request, CancellationToken cancellationToken)
        {
            var about = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(About).Name, request.Id.ToString());

            // Update here
            about.Description = request.Description;
            about.Title = request.Title;
            about.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(about);
        }
    }
}
