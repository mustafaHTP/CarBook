using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.Services
{
    public interface IApiService
    {
        Task<T?> GetAsync<T>(string url) where T : class;
    }
}
