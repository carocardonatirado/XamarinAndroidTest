using System.Threading.Tasks;
using Plugin.Connectivity;
using TestPeople.Logic.Business.Contracts;
using TestPeople.Logic.Resources;

namespace TestPeople.Utilities
{
    class DeviceManager : IDeviceManager
    {
        private static DeviceManager instance;

        public static DeviceManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new DeviceManager();
                }

                return instance;
            }
        }

        public async Task<bool> IsNetworkAvailableAsync()
        {
            bool isConnected = false;

            if (CrossConnectivity.IsSupported)
            {
                var connectivity = CrossConnectivity.Current;

                try
                {
                    isConnected = connectivity.IsConnected;
                    isConnected = isConnected ? await connectivity.IsRemoteReachable(Configurations.ReachableUrl) : isConnected;
                }
                catch
                {
                }
                finally
                {
                    CrossConnectivity.Dispose();
                }
            }

            return isConnected;
        }
    }
}