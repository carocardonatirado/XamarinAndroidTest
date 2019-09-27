using TestPeople.Logic.Business.Dtos;

namespace TestPeople.Interfaces
{
    public interface IPeople
    {
        void OnItemSelected(People person, int action);
    }
}