using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.AuthFeatures.Results
{
    public class LoginAppUserQueryResult
    {
        public bool IsAuthenticated { get; set; }
        public string? Token { get; set; }
    }
}
