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
    public class GetReservationPricingsQueryHandler : IRequestHandler<GetReservationPricingsQuery, List<GetReservationPricingsQueryResult>>
    {
        private readonly IRepository<ReservationPricing> _repository;

        public GetReservationPricingsQueryHandler(IRepository<ReservationPricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationPricingsQueryResult>> Handle(GetReservationPricingsQuery request, CancellationToken cancellationToken)
        {
            var reservationPricings = await _repository.GetAllAsync();

            return reservationPricings.Select(r => new GetReservationPricingsQueryResult()
            {
                Id = r.Id,
                Name = r.Name,
            }).ToList();
        }
    }
}
