using CarBook.Application.Features.BlogTagFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagFeatures.Handlers
{
    public class DeleteBlogTagCommandHandler : IRequestHandler<DeleteBlogTagCommand>
    {
        private readonly IRepository<BlogTag> _repository;

        public DeleteBlogTagCommandHandler(IRepository<BlogTag> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBlogTagCommand request, CancellationToken cancellationToken)
        {
            var blogTag = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(blogTag);
        }
    }
}
