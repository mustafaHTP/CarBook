﻿using CarBook.Application.Features.SocialMediaFeatures.Commands;
using CarBook.Application.Interfaces.Repositories;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.SocialMediaFeatures.Handlers
{
    public class DeleteSocialMediaCommandHandler : IRequestHandler<DeleteSocialMediaCommand>
    {
        private readonly IRepository<SocialMedia> _repository;

        public DeleteSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }


        public async Task Handle(DeleteSocialMediaCommand request, CancellationToken cancellationToken)
        {
            var socialMediaToBeDeleted = await _repository.GetByIdAsync(request.Id);

            await _repository.DeleteAsync(socialMediaToBeDeleted);
        }
    }
}
