using CarBook.Application.Exceptions;
using CarBook.Application.Features.FooterAddressFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FooterAddressFeatures.Handlers
{
    public class UpdateFooterAddressCommandHandler : IRequestHandler<UpdateFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public UpdateFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddress = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException<FooterAddress>(request.Id);

            //update here
            footerAddress.Description = request.Description;
            footerAddress.Phone = request.Phone;
            footerAddress.Address = request.Address;
            footerAddress.Email = request.Email;

            await _repository.UpdateAsync(footerAddress);
        }
    }
}
