using CarBook.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Exceptions
{
    public class NotFoundException<T> : Exception where T : class
    {
        public NotFoundException() { }

        public NotFoundException(string? message)
            : base(message) { }

        public NotFoundException(int id)
            : base($"{typeof(T).Name} with ID {id} not found.") { }

        public NotFoundException(string? message, Exception? innerException)
            : base(message, innerException) { }
    }
}
