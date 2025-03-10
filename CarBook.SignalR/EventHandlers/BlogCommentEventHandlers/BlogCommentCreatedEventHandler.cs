using CarBook.Application.DomainEvents.BlogCommentEvents;
using CarBook.Application.Dtos.BlogCommentDtos;
using CarBook.Application.Dtos.BlogDtos;
using CarBook.Application.Exceptions;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using CarBook.SignalR.Hubs;
using MediatR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.SignalR.EventHandlers.BlogCommentEventHandlers
{
    public class BlogCommentCreatedEventHandler : INotificationHandler<BlogCommentCreatedEvent>
    {
        private readonly IBlogCommentRepository _repository;
        private readonly IHubContext<NotificationHub> _hubContext;

        public BlogCommentCreatedEventHandler(IBlogCommentRepository repository, IHubContext<NotificationHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

        public async Task Handle(BlogCommentCreatedEvent notification, CancellationToken cancellationToken)
        {
            var blogComment = _repository.GetById(notification.BlogCommentId)
                ?? throw new NotFoundException(typeof(BlogComment).Name, notification.BlogCommentId.ToString());

            var blogCommentDto = new BlogCommentCreatedEventDto
            {
                Id = blogComment.Id,
                BlogId = blogComment.BlogId,
                Blog = new BlogLiteDto
                {
                    Id = blogComment.Blog.Id,
                    Title = blogComment.Blog.Title
                },
                Content = blogComment.Content,
                CreatedDate = blogComment.CreatedDate,
                Email = blogComment.Email,
                Name = blogComment.Name
            };

            await _hubContext.Clients.All.SendAsync("ReceiveNotification", blogCommentDto, cancellationToken);
        }
    }
}
