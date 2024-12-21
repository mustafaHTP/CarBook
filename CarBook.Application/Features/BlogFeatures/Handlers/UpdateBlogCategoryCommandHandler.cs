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
    public class UpdateBlogCategoryCommandHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public UpdateBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCategoryCommand updateBlogCategoryCommand)
        {
            var blogCategoryToBeUpdated = await _repository.GetByIdAsync(updateBlogCategoryCommand.Id);
            //update here
            blogCategoryToBeUpdated.Name = updateBlogCategoryCommand.Name;

            await _repository.UpdateAsync(blogCategoryToBeUpdated);
        }
    }
}
