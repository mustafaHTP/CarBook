using CarBook.Application.Features.BlogCommentFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Handlers
{
    public class CreateBlogCommentCommandHandler : IRequestHandler<CreateBlogCommentCommand>
    {
        private readonly IRepository<BlogComment> _repository;

        public CreateBlogCommentCommandHandler(IRepository<BlogComment> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommentCommand request, CancellationToken cancellationToken)
        {
            var blogComment = new BlogComment
            {
                Name = request.Name,
                CreatedDate = request.CreatedDate,
                Content = request.Content,
                BlogId = request.BlogId
            };

            await _repository.CreateAsync(blogComment);
        }
    }
}
