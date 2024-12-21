using CarBook.Application.Features.FeatureFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.FeatureFeatures.Queries
{
    public class GetAllFeaturesQuery : IRequest<List<GetAllFeaturesQueryResult>>
    {

    }
}
