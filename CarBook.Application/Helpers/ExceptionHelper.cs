using CarBook.Application.Exceptions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Helpers
{
    public static class ExceptionHelper
    {
        /// <summary>
        /// Throws a NotFoundException with a message that the entity of type T with the given ID was not found.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <exception cref="NotFoundException{T}"></exception>
        public static void ThrowIfNotFound<T>(int id) where T : class
        {
            throw new NotFoundException($"{typeof(T).Name} with ID {id} not found.");
        }
    }
}
