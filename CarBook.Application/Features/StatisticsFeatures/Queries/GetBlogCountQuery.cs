﻿using CarBook.Application.Features.StatisticsFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.StatisticsFeatures.Queries
{
    public class GetBlogCountQuery : IRequest<GetBlogCountQueryResult>
    {
    }
}
