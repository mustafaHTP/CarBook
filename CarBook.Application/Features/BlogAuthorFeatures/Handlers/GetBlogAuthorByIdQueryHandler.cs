using CarBook.Application.Features.BlogAuthorFeatures.Queries;
using CarBook.Application.Features.BlogAuthorFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogAuthorFeatures.Handlers
{
    public class GetBlogAuthorByIdQueryHandler : IRequestHandler<GetBlogAuthorByIdQuery, GetBlogAuthorByIdQueryResult>
    {
        private readonly IBlogAuthorRepository _repository;

        public GetBlogAuthorByIdQueryHandler(IBlogAuthorRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogAuthorByIdQueryResult> Handle(GetBlogAuthorByIdQuery request, CancellationToken cancellationToken)
        {
            var blogAuthor = await _repository.GetByIdAsync(request.Id);
            var result = new GetBlogAuthorByIdQueryResult
            {
                Id = blogAuthor.Id,
                Name = blogAuthor.Name,
                Description = blogAuthor.Description,
                ImageUrl = blogAuthor.ImageUrl
            };

            return await Task.FromResult(result);
        }
    }
}
