using CarBook.Application.Features.SocialMediaFeatures.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.SocialMediaFeatures.Queries
{
    public class GetSocialMediaByIdQuery : IRequest<GetSocialMediaByIdQueryResult>
    {
        public int Id { get; set; }
    }
}
