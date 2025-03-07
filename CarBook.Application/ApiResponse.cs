﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application
{
    public record ApiResponse<T>(bool IsSuccessful, string? Message, T? Result) where T : class
    {
        public static ApiResponse<T> Success(string? message, T? result)
        {
            return new(true, message, result);
        }

        public static ApiResponse<T> Failure(string? message)
        {
            return new(false, message, null);
        }
    }

    public record ApiResponse(bool IsSuccessful, string? Message)
    {
        public static ApiResponse Success(string? message)
        {
            return new(true, message);
        }

        public static ApiResponse Failure(string? message)
        {
            return new(false, message);
        }
    }
}
