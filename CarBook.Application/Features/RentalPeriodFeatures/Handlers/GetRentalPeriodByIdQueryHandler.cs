using CarBook.Application.Exceptions;
using CarBook.Application.Features.PricingPlanFeatures.Queries;
using CarBook.Application.Features.PricingPlanFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.PricingPlanFeatures.Handlers
{
    public class GetRentalPeriodByIdQueryHandler : IRequestHandler<GetRentalPeriodByIdQuery, GetRentalPeriodByIdQueryResult>
    {
        private readonly IRepository<RentalPeriod> _repository;

        public GetRentalPeriodByIdQueryHandler(IRepository<RentalPeriod> repository)
        {
            _repository = repository;
        }

        public async Task<GetRentalPeriodByIdQueryResult> Handle(GetRentalPeriodByIdQuery request, CancellationToken cancellationToken)
        {
            var rentalPeriod = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<RentalPeriod>(request.Id);

            return new GetRentalPeriodByIdQueryResult()
            {
                Id = rentalPeriod.Id,
                Name = rentalPeriod.Name
            };
        }
    }
}
