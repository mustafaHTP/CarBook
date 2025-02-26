using CarBook.Application.Features.CarReviewFeatures.Queries;
using CarBook.Application.Features.CarReviewFeatures.Results;
using CarBook.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CarReviewFeatures.Handlers
{
    public class GetCarReviewsByCarIdQueryHandler : IRequestHandler<GetCarReviewsByCarIdQuery, IEnumerable<GetCarReviewsByCarIdQueryResult>>
    {
        private readonly ICarReviewRepository _repository;

        public GetCarReviewsByCarIdQueryHandler(ICarReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<GetCarReviewsByCarIdQueryResult>> Handle(GetCarReviewsByCarIdQuery request, CancellationToken cancellationToken)
        {
            var carReviews = _repository.GetAllByCarId(request.CarId);
            var result = carReviews.Select(cr => new GetCarReviewsByCarIdQueryResult
            {
                CarId = cr.CarId,
                Car = cr.Car,
                CustomerId = cr.CustomerId,
                Customer = cr.Customer,
                Review = cr.Review,
                ReviewDate = cr.ReviewDate,
                RatingStarCount = cr.RatingStarCount
            });

            return await Task.FromResult(result);
        }
    }
}
