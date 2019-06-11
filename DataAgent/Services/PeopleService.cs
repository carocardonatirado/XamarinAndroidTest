using Contracts.Interfaces;
using Entities.Response;
using System;
using System.Threading.Tasks;
using Utilities.Resources;
using Newtonsoft.Json;
using System.Collections.Generic;
using Entities.Business;

namespace DataAgent.Services
{
    public class PeopleService : BaseApiService, IPeopleService
    {
        public PeopleService(IDeviceManager deviceManager)
            : base(deviceManager)
        {
        }

        public async Task<PeopleResponse> GetPeople()
        {
            PeopleResponse peopleResponse = new PeopleResponse();
            string endpoint = Configurations.UsersEndPoint;
            var response = await HttpClientBaseService.GetAsync(endpoint);

            if (response.Content == null)
            {
                return (PeopleResponse)Convert.ChangeType(response, typeof(PeopleResponse));
            }
            else
            {
                string data = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(data))
                {
                    return new PeopleResponse
                    {
                    };
                }

                var result = JsonConvert.DeserializeObject<IList<Person>>(data);
                peopleResponse.People = result;
                return peopleResponse;
            }
        }
    }
}
