﻿using Contracts.Interfaces;

namespace DataAgent.Services
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
