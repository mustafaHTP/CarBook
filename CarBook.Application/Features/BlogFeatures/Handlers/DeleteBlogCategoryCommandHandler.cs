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
    public class DeleteBlogCategoryCommandHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public DeleteBlogCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }

        public async Task Handle(DeleteBlogCategoryCommand deleteBlogCategoryCommand)
        {
            var blogCategoryToBeDeleted = await _repository.GetByIdAsync(deleteBlogCategoryCommand.Id);
            await _repository.DeleteAsync(blogCategoryToBeDeleted);
        }
    }
}
