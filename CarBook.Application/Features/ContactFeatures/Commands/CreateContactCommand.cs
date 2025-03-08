﻿using MediatR;

namespace CarBook.Application.Features.ContactFeatures.Commands
{
    public class CreateContactCommand : IRequest
    {
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Subject { get; set; } = null!;
        public string Message { get; set; } = null!;
        public DateTime SendDate { get; set; }
    }
}
