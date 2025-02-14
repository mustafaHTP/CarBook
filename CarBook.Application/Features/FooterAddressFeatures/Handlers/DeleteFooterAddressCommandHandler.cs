using CarBook.Application.Features.FooterAddressFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.FooterAddressFeatures.Handlers
{
    public class DeleteFooterAddressCommandHandler : IRequestHandler<DeleteFooterAddressCommand>
    {
        private readonly IRepository<FooterAddress> _repository;

        public DeleteFooterAddressCommandHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteFooterAddressCommand request, CancellationToken cancellationToken)
        {
            var footerAddressToBeDeleted = await _repository.GetByIdAsync(request.Id);
            await _repository.DeleteAsync(footerAddressToBeDeleted);
        }
    }
}
