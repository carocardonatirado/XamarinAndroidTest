using Contracts.Interfaces;
using Entities.Business;
using Entities.Response;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class PeopleModel
    {
        private IPeopleService _peopleService { get; set; }
        private IDocumentsDataBase _documentsDataBase { get; set; }       

        public PeopleModel(IPeopleService peopleService, IDocumentsDataBase documentsDataBase)
        {
            _peopleService = peopleService;
            _documentsDataBase = documentsDataBase;
        }

        public async Task<PeopleResponse> GetPeople()
        {
            PeopleResponse response = new PeopleResponse();

            if (_documentsDataBase.ExistPeople())
            {
                response.People = _documentsDataBase.GetPeople();
            }
            else
            {
                response = await _peopleService.GetPeople();

                if (response != null && response.People != null && response.People.Any())
                {
                    SavePeople(response.People);
                }
            }

            return response;
        }

        private void SavePeople(IList<Person> people)
        {
            foreach (Person person in people)
            {
                _documentsDataBase.UpSerPerson(person);
            }
        }
    }
}
