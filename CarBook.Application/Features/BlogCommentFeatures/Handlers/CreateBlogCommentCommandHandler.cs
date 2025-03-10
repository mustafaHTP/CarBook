using CarBook.Application.DomainEvents.BlogCommentEvents;
using CarBook.Application.Features.BlogCommentFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.BlogCommentFeatures.Handlers
{
    public class CreateBlogCommentCommandHandler : IRequestHandler<CreateBlogCommentCommand>
    {
        private readonly IRepository<BlogComment> _repository;
        private readonly IMediator _mediator;

        public CreateBlogCommentCommandHandler(IRepository<BlogComment> repository, IMediator mediator)
        {
            _repository = repository;
            _mediator = mediator;
        }

        public async Task Handle(CreateBlogCommentCommand request, CancellationToken cancellationToken)
        {
            var blogComment = new BlogComment
            {
                Name = request.Name,
                Email = request.Email,
                CreatedDate = request.CreatedDate,
                Content = request.Content,
                BlogId = request.BlogId
            };

            await _repository.CreateAsync(blogComment);

            await _mediator.Publish(new BlogCommentCreatedEvent(blogComment.Id), cancellationToken);
        }
    }
}
