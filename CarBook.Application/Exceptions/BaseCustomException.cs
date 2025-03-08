using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Exceptions
{
    public abstract class BaseCustomException : Exception
    {
        public abstract string MessageFormat { get; }
        public abstract string Title { get; }
        public abstract HttpStatusCode StatusCode { get; }
        public abstract Dictionary<string, string> MessageProps { get; set; }
    }
}
