using CarBook.Application.Features.FooterAddressFeatures.Commands;
using CarBook.Application.Interfaces;
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
            var footerAddressToBeUpdated = await _repository.GetByIdAsync(request.Id);

            //update here
            footerAddressToBeUpdated.Description = request.Description;
            footerAddressToBeUpdated.Phone = request.Phone;
            footerAddressToBeUpdated.Address = request.Address;
            footerAddressToBeUpdated.Email = request.Email;

            await _repository.UpdateAsync(footerAddressToBeUpdated);
        }
    }
}
