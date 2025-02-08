﻿using CarBook.Application.Features.BlogTagCloudFeatures.Commands;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BlogTagCloudFeatures.Handlers
{
    public class CreateBlogTagCloudCommandHandler : IRequestHandler<CreateBlogTagCloudCommand>
    {
        private readonly IRepository<BlogTagCloud> _repository;

        public CreateBlogTagCloudCommandHandler(IRepository<BlogTagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogTagCloudCommand request, CancellationToken cancellationToken)
        {
            var blogTagCloud = new BlogTagCloud
            {
                BlogId = request.BlogId,
                BlogTagId = request.BlogTagId
            };

            await _repository.CreateAsync(blogTagCloud);
        }
    }
}
