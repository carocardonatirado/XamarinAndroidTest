using System.Collections.Generic;
using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Logic.Business.Contracts
{
    public interface IDocumentsDataBase
    {
        bool ExistPeople();
        List<People> GetPeople();
        void UpSerPerson(People person);
    }
}
