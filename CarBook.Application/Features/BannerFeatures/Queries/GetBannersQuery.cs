﻿using CarBook.Application.Features.BannerFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.BannerFeatures.Queries
{
    public class GetBannersQuery : IRequest<List<GetBannersQueryResult>>
    {
    }
}
