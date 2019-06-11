using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string serviceUrl);
    }
}
