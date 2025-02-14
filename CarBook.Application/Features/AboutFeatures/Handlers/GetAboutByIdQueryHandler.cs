using CarBook.Application.Features.AboutFeatures.Queries;
using CarBook.Application.Features.AboutFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;

namespace CarBook.Application.Features.AboutFeatures.Handlers
{
    public class GetAboutByIdQueryHandler : IRequestHandler<GetAboutByIdQuery, GetAboutByIdQueryResult>
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResult> Handle(GetAboutByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetAboutByIdQueryResult
            {
                Id = value.Id,
                Description = value.Description,
                ImageUrl = value.ImageUrl,
                Title = value.Title,
            };
        }
    }
}
