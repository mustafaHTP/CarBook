using CarBook.Application.Features.FooterAddressFeatures.Queries;
using CarBook.Application.Features.FooterAddressFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FooterAddressFeatures.Handlers
{
    public class GetFooterAddressesQueryHandler : IRequestHandler<GetFooterAddressesQuery, List<GetFooterAddressesQueryResult>>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressesQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressesQueryResult>> Handle(GetFooterAddressesQuery request, CancellationToken cancellationToken)
        {
            var footerAddresses = await _repository.GetAllAsync();

            return footerAddresses.Select(f => new GetFooterAddressesQueryResult()
            {
                Address = f.Address,
                Description = f.Description,
                Email = f.Email,
                Phone = f.Phone,
                Id = f.Id,
            }).ToList();
        }
    }
}
