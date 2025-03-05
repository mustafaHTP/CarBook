using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application
{
    public record ApiResponse<T>(bool IsSuccessful, string? Message, T? Result) where T : class
    {
        public static ApiResponse<T> CreateResponse(bool isSuccessful, string? message, T? result)
        {
            return new(isSuccessful, message, result);
        }
    }
}
