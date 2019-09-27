using TestPeople.Logic.Business.Contracts;

namespace TestPeople.Logic.Repositories.Remote.Base
{
    public class BaseApiService
    {
        private IHttpClientService httpClientBaseService;
        public IHttpClientService HttpClientBaseService { get => httpClientBaseService; set => httpClientBaseService = value; }

        private IDeviceManager deviceManager;
        public IDeviceManager DeviceManager { get => deviceManager; set => deviceManager = value; }

        public BaseApiService(IDeviceManager deviceManager)
        {
            this.deviceManager = deviceManager;

            if (httpClientBaseService == null)
                httpClientBaseService = new HttpClientService(DeviceManager);
        }
    }
}
