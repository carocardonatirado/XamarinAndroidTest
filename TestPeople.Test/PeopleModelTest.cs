using Contracts.Interfaces;
using Entities.Business;
using Entities.Response;
using Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TestPeople.Test
{
    public class PeopleModelTest
    {
        protected Mock<IPeopleService> peopleService;
        protected Mock<IDocumentsDataBase> documentsDataBase;
        protected Mock<IHttpClientService> HttpClientService;
        protected PeopleModel model;

        public PeopleModelTest()
        {
            peopleService = new Mock<IPeopleService>();
            documentsDataBase = new Mock<IDocumentsDataBase>();
            HttpClientService = new Mock<IHttpClientService>();
            model = new PeopleModel(peopleService.Object, documentsDataBase.Object);
        }

        [Fact]
        public async Task GetPeopleFromTheServiceSuccessful()
        {
            var people = new List<Person>
            {
                new Person { Id = 1, Name = "any", Email= "any@any.com" }
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
                People = new List<Person>()
            };

            peopleService.Setup(_ => _.GetPeople()).ReturnsAsync(response);

            // Action
            var actual = await model.GetPeople();

            // Assert
            Assert.True(!response.People.Any());
        }
    }
}
