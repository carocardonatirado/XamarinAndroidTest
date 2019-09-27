using System.Threading.Tasks;
using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Logic.Business.Contracts
{
    public interface IPeopleService
    {
        Task<PeopleResponse> GetPeople();
    }
}
