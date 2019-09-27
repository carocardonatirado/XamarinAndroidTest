using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Business.Dtos;
using TestPeople.Logic.Repositories.Remote.Base;
using TestPeople.Logic.Resources;

namespace DTestPeople.Logic.Repositories.Remote
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

                var result = JsonConvert.DeserializeObject<IList<People>>(data);
                peopleResponse.People = result;
                return peopleResponse;
            }
        }
    }
}
