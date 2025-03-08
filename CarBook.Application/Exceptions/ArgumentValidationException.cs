using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Exceptions
{
    public class ArgumentValidationException : Exception
    {
        public string MessageFormat => "Not Defined";

        public string Title => "Validation Error";

        public HttpStatusCode StatusCode => HttpStatusCode.BadRequest;

        public IEnumerable<string> MessageProps { get; set; }

        public ArgumentValidationException(IDictionary<string, string[]> messageProps)
        {
            MessageProps = messageProps
                .SelectMany(kvp => kvp.Value.Select(v => $"{kvp.Key}: {v}"));
        }
    }
}
