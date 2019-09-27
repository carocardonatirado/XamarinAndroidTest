using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Business.Dtos;
using TestPeople.Logic.Business.Managers;
using Xunit;

namespace TestPeople.Test
{
    public class PeopleModelTest
    {
        protected Mock<IPeopleService> peopleService;
        protected Mock<IDocumentsDataBase> documentsDataBase;
        protected Mock<IHttpClientService> HttpClientService;
        protected PeopleManager model;

        public PeopleModelTest()
        {
            peopleService = new Mock<IPeopleService>();
            documentsDataBase = new Mock<IDocumentsDataBase>();
            HttpClientService = new Mock<IHttpClientService>();
            model = new PeopleManager(peopleService.Object, documentsDataBase.Object);
        }

        [Fact]
        public async Task GetPeopleFromTheServiceSuccessful()
        {
            var people = new List<People>
            {
                new People { Id = 1, Name = "any", Email= "any@any.com" }
            };

            var response = new PeopleResponse()
            {
                People = people
            };

            peopleService.Setup(_ => _.GetPeople()).ReturnsAsync(response);

            // Action
            var actual = await model.GetPeople();

            // Assert
            Assert.True(response.People.Any());
        }

        [Fact]
        public async Task GetPopleServiceDoesNotReturnInformation()
        {
            var response = new PeopleResponse()
            {
                People = new List<People>()
            };

            peopleService.Setup(_ => _.GetPeople()).ReturnsAsync(response);

            // Action
            var actual = await model.GetPeople();

            // Assert
            Assert.True(!response.People.Any());
        }
    }
}
