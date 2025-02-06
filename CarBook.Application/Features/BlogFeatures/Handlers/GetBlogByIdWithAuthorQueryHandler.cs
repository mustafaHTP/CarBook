using CarBook.Application.Features.BlogFeatures.Queries;
using CarBook.Application.Features.BlogFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogFeatures.Handlers
{
    public class GetBlogByIdWithAuthorQueryHandler : IRequestHandler<GetBlogByIdWithAuthorQuery, GetBlogByIdWithAuthorQueryResult>
    {
        private readonly IBlogRepository _repository;

        public GetBlogByIdWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdWithAuthorQueryResult> Handle(GetBlogByIdWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var blog = _repository.GetByIdWithAuthor(request.Id);
            var result = new GetBlogByIdWithAuthorQueryResult
            {
                Id = blog.Id,
                Title = blog.Title,
                Content = blog.Content,
                Description = blog.Description,
                CoverImageUrl = blog.CoverImageUrl,
                CreatedDate = blog.CreatedDate,
                BlogAuthorId = blog.BlogAuthorId,
                BlogAuthorName = blog.BlogAuthor.Name,
                BlogAuthorDescription = blog.BlogAuthor.Description,
                BlogAuthorImageUrl = blog.BlogAuthor.ImageUrl
            };

            return await Task.FromResult(result);
        }
    }
}
