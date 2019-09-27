using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Business.Dtos;
using TestPeople.Logic.Repositories.Remote.Base;
using TestPeople.Logic.Resources;

namespace TestPeople.Logic.Repositories.Remote
{
    public class BookService : BaseApiService, IBookService
    {
        public BookService(IDeviceManager deviceManager)
         : base(deviceManager)
        {
        }

        public async Task<BookResponse> GetBooks()
        {
            BookResponse peopleResponse = new BookResponse();
            string endpoint = Configurations.bookEndPoint;
            var response = await HttpClientBaseService.GetAsync(endpoint);

            if (response.Content == null)
            {
                return (BookResponse)Convert.ChangeType(response, typeof(BookResponse));
            }
            else
            {
                string data = await response.Content.ReadAsStringAsync();

                if (string.IsNullOrEmpty(data))
                {
                    return new BookResponse
                    {
                    };
                }

                var result = JsonConvert.DeserializeObject<IList<Book>>(data);
                peopleResponse.Books = result;
                return peopleResponse;
            }
        }
    }
}
