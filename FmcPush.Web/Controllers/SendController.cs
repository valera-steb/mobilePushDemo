using FirebaseAdmin.Messaging;
using FmcPush.Web.Domain.FireBaseApp;
using FmcPush.Web.Domain.MobileDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;

namespace FmcPush.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        private readonly IFireBaseAppProvider fireBaseAppProvider;
        private readonly IMobileDevicesService mobileDevicesService;
        private readonly ILogger<SendController> logger;


        public SendController(
            IFireBaseAppProvider fireBaseAppProvider, IMobileDevicesService mobileDevicesService,
            ILogger<SendController> logger)
        {
            this.fireBaseAppProvider = fireBaseAppProvider;
            this.mobileDevicesService = mobileDevicesService;
            this.logger = logger;
        }


        [HttpPost]
        public async void Post()
        {
            var app = fireBaseAppProvider.Get();
            var firebaseMessaging = FirebaseMessaging.GetMessaging(app);

            var to = mobileDevicesService.GetAll().ToList();
            logger.LogInformation("Sending to {0} devices", to.Count);

            var message = new MulticastMessage
            {
                Notification = new Notification
                {
                    Title = "Hello from api",
                    Body = "Test message"
                },
                Android = new AndroidConfig
                {
                    TimeToLive = TimeSpan.FromMinutes(1)
                },
                Tokens = to
            };


            var result = await firebaseMessaging.SendMulticastAsync(message);
            logger.LogInformation("responce: {0}", JsonConvert.SerializeObject(result));
        }
    }
}
