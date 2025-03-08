using CarBook.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException() { }

        public NotFoundException(string? message)
            : base(message) { }

        public NotFoundException(Type type, int id)
            : base($"{type.Name} with ID {id} not found.") { }

        public NotFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
