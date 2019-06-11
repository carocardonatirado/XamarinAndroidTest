using Entities.Business;
using System.Collections.Generic;

namespace Contracts.Interfaces
{
    public interface IDocumentsDataBase
    {
        bool ExistPeople();
        List<Person> GetPeople();
        void UpSerPerson(Person person);
    }
}
