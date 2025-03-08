using CarBook.Application.Exceptions;
using CarBook.Application.Features.PricingPlanFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class UpdateRentalPeriodCommandHandler : IRequestHandler<UpdateRentaPeriodCommand>
    {
        private readonly IRepository<RentalPeriod> _repository;

        public UpdateRentalPeriodCommandHandler(IRepository<RentalPeriod> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateRentaPeriodCommand request, CancellationToken cancellationToken)
        {
            var rentalPeriod = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(RentalPeriod).Name, request.Id.ToString());

            rentalPeriod.Name = request.Name;

            await _repository.UpdateAsync(rentalPeriod);
        }
    }
}
