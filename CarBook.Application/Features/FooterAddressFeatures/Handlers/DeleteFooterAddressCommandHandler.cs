using CarBook.Application.Exceptions;
using CarBook.Application.Features.FooterAddressFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
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
            var footerAddress = await _repository.GetByIdAsync(request.Id)
                ?? throw new NotFoundException(typeof(FooterAddress), request.Id);

            await _repository.DeleteAsync(footerAddress);
        }
    }
}
