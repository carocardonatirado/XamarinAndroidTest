using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Logic.Business.Managers
{
    public class PeopleManager
    {
        private IPeopleService _peopleService { get; set; }
        private IDocumentsDataBase _documentsDataBase { get; set; }       

        public PeopleManager(IPeopleService peopleService, IDocumentsDataBase documentsDataBase)
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

        private void SavePeople(IEnumerable<People> people)
        {
            foreach (People person in people)
            {
                _documentsDataBase.UpSerPerson(person);
            }
        }
    }
}
