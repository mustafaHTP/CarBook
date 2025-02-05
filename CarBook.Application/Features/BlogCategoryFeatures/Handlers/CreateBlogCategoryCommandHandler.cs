using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class CreateBlogCategoryCommandHandler : IRequestHandler<CreateBlogCategoryCommand>
    {
        private readonly IRepository<BlogCategory> _repository;

        public CreateBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCategoryCommand request, CancellationToken cancellationToken)
        {
            var blogCategory = new BlogCategory()
            {
                Name = request.Name
            };

            await _repository.CreateAsync(blogCategory);
        }
    }
}
