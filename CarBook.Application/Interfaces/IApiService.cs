using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces
{
    public interface IApiService
    {
        Task<T?> Get<T>(string url) where T : class;
    }
}
