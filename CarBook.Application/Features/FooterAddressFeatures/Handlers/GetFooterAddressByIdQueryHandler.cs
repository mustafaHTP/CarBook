using CarBook.Application.Exceptions;
using CarBook.Application.Features.FooterAddressFeatures.Queries;
using CarBook.Application.Features.FooterAddressFeatures.Results;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FooterAddressFeatures.Handlers
{
    public class GetFooterAddressByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(FooterAddress), request.Id);

            return new GetFooterAddressByIdQueryResult()
            {
                Address = footerAddress.Address,
                Description = footerAddress.Description,
                Email = footerAddress.Email,
                Id = footerAddress.Id,
                Phone = footerAddress.Phone
            };
        }
    }
}
