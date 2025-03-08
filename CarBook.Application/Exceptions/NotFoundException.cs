using CarBook.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Exceptions
{
    public sealed class NotFoundException : BaseCustomException
    {
        public NotFoundException(string typeName, string id) : base()
        {
            MessageProps = new()
            {
                { "{typeName}", typeName },
                { "{id}", id }
            };
        }

        public override string MessageFormat => "{typeName} with ID {id} not found.";
        public override string Title => "Not Found Error";
        public override HttpStatusCode StatusCode => HttpStatusCode.NotFound;
        public override Dictionary<string, string> MessageProps { get; set; }
    }
}
