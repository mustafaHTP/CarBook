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
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = await _repository.GetByIdAsync(request.Id);

            // Update here
            blog.BlogAuthorId = request.BlogAuthorId;
            blog.BlogCategoryId = request.BlogCategoryId;
            blog.Title = request.Title;
            blog.Content = request.Content;
            blog.CoverImageUrl = request.CoverImageUrl;

            await _repository.UpdateAsync(blog);
        }
    }
}
