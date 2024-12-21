using CarBook.Application.Features.BlogFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class CreateBlogCategoryCommandHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public CreateBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCategoryCommand createBlogCategoryCommand)
        {
            var blogCategoryToBeCreated = new BlogCategory()
            {
                Name = createBlogCategoryCommand.Name
            };

            await _repository.CreateAsync(blogCategoryToBeCreated);
        }
    }
}
