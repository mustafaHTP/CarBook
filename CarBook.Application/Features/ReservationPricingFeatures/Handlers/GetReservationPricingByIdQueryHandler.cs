using CarBook.Application.Features.ReservationPricingFeatures.Queries;
using CarBook.Application.Features.ReservationPricingFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.ReservationPricingFeatures.Handlers
{
    public class GetReservationPricingByIdQueryHandler : IRequestHandler<GetReservationPricingByIdQuery, GetReservationPricingByIdQueryResult>
    {
        private readonly IRepository<ReservationPricing> _repository;

        public GetReservationPricingByIdQueryHandler(IRepository<ReservationPricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetReservationPricingByIdQueryResult> Handle(GetReservationPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var reservationPricing = await _repository.GetByIdAsync(request.Id);

            return new GetReservationPricingByIdQueryResult()
            {
                Id = reservationPricing.Id,
                Name = reservationPricing.Name
            };
        }
    }
}
