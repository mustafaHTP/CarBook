using CarBook.Application.Features.CarReviewFeatures.Queries;
using CarBook.Application.Features.CarReviewFeatures.Results;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarReviewFeatures.Handlers
{
    public class GetCarReviewsQueryHandler : IRequestHandler<GetCarReviewsQuery, IEnumerable<GetCarReviewsQueryResult>>
    {
        private readonly IRepository<CarReview> _repository;

        public GetCarReviewsQueryHandler(IRepository<CarReview> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCarReviewsQueryResult>> Handle(GetCarReviewsQuery request, CancellationToken cancellationToken)
        {
            var carReviews = await _repository.GetAllAsync();
            var result = carReviews.Select(cr => new GetCarReviewsQueryResult
            {
                Id = cr.Id,
                CarId = cr.CarId,
                CustomerId = cr.CustomerId,
                Review = cr.Review,
                ReviewDate = cr.ReviewDate,
                RatingStarCount = cr.RatingStarCount
            });

            return await Task.FromResult(result);
        }
    }
}
