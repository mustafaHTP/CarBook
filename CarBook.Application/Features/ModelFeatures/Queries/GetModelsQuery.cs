﻿using CarBook.Application.Features.ModelFeatures.Results;
using MediatR;

namespace CarBook.Application.Features.ModelFeatures.Queries
{
    public class GetModelsQuery : IRequest<List<GetModelsQueryResult>>
    {
        public bool IncludeCars { get; set; }
    }
}
