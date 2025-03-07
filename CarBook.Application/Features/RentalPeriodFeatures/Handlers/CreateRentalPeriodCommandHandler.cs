using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class CreateRentalPeriodCommandHandler : IRequestHandler<CreateRentaPeriodCommand>
    {
        private readonly IRepository<RentalPeriod> _repository;

        public CreateRentalPeriodCommandHandler(IRepository<RentalPeriod> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateRentaPeriodCommand request, CancellationToken cancellationToken)
        {
            var rentalPeriod = new RentalPeriod()
            {
                Name = request.Name,
            };

            await _repository.CreateAsync(rentalPeriod);
        }
    }
}
