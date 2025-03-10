using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.DomainEvents.BlogCommentEvents
{
    public class BlogCommentCreatedEvent : INotification
    {
        public int BlogCommentId { get; set; }

        public BlogCommentCreatedEvent(int blogCommentId)
        {
            BlogCommentId = blogCommentId;
        }
    }
}
