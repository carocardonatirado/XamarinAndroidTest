using System.Threading.Tasks;

namespace TestPeople.Logic.Business.Contracts
{ 
    public interface IDeviceManager
    {
        Task<bool> IsNetworkAvailableAsync();
    }
}
