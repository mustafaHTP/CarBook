using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Exceptions
{
    public sealed class AlreadyExistsException : BaseCustomException
    {
        public override string MessageFormat => "{propName}: {propValue} already exists";
        public override string Title => "Already Exists Error";
        public override HttpStatusCode StatusCode => HttpStatusCode.BadRequest;
        public override Dictionary<string, string> MessageProps { get; set; } = [];

        public AlreadyExistsException(string propName, string propValue) : base()
        {
            MessageProps.Add("{propName}", propName);
            MessageProps.Add("{propValue}", propValue);
        }
    }
}
