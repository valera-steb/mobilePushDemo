using FmcPush.Web.Domain.MobileDevices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace FmcPush.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeviceController : ControllerBase
    {
        private readonly IMobileDevicesService mobileDevicesService;
        private readonly ILogger<DeviceController> logger;

        public DeviceController(IMobileDevicesService mobileDevicesService, ILogger<DeviceController> logger)
        {
            this.mobileDevicesService = mobileDevicesService;
            this.logger = logger;
        }


        [HttpPost]
        public void Post([FromBody] string token)
        {
            logger.LogInformation("Has device token: {0}", token);
            mobileDevicesService.Add(token);
        }
    }
}
