using System.Net.Http;
using System.Threading.Tasks;

namespace TestPeople.Logic.Business.Contracts
{
    public interface IHttpClientService
    {
        Task<HttpResponseMessage> GetAsync(string serviceUrl);
    }
}
