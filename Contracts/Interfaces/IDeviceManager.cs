using System.Threading.Tasks;

namespace Contracts.Interfaces
{
    public interface IDeviceManager
    {
        Task<bool> IsNetworkAvailableAsync();
    }
}
