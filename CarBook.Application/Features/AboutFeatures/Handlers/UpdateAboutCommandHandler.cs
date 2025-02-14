using CarBook.Application.Features.AboutFeatures.Commands;
using CarBook.Application.Interfaces;
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
            var aboutToBeUpdated = await _repository.GetByIdAsync(request.Id);

            // Update here
            aboutToBeUpdated.Description = request.Description;
            aboutToBeUpdated.Title = request.Title;
            aboutToBeUpdated.ImageUrl = request.ImageUrl;

            await _repository.UpdateAsync(aboutToBeUpdated);
        }
    }
}
