using CarBook.Application.Exceptions;
using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class DeleteRentalPeriodCommandHandler : IRequestHandler<DeleteRentalPeriodCommand>
    {
        private readonly IRepository<RentalPeriod> _repository;

        public DeleteRentalPeriodCommandHandler(IRepository<RentalPeriod> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteRentalPeriodCommand request, CancellationToken cancellationToken)
        {
            var rentalPeriod = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<RentalPeriod>(request.Id);

            await _repository.DeleteAsync(rentalPeriod);
        }
    }
}
