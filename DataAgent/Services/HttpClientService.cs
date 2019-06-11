using Contracts.Interfaces;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace DataAgent.Services
{
    public class HttpClientService : IHttpClientService
    {
        private IDeviceManager _deviceManager;

        public HttpClientService(IDeviceManager deviceManager)
        {
            _deviceManager = deviceManager;
        }

        public async Task<HttpResponseMessage> GetAsync(string serviceUrl)
        {
            try
            {               
                if (await _deviceManager.IsNetworkAvailableAsync())
                {
                    using (var client = new HttpClient())
                    {
                        return await client.GetAsync(new Uri(serviceUrl));
                    }
                }
                else
                {
                    return new HttpResponseMessage { StatusCode = HttpStatusCode.RequestTimeout };
                }
            }
            catch
            {
                return new HttpResponseMessage { StatusCode = HttpStatusCode.BadRequest };
            }
        }
    }
}
