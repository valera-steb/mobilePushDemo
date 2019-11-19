using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace FmcPush.Web.Domain.MobileDevices
{
    public interface IMobileDevicesService
    {
        void Add(string token);
        IEnumerable<string> GetAll ();
    }

    public class MobileDevicesService : IMobileDevicesService
    {
        private readonly ConcurrentBag<string> concurrentBag = new ConcurrentBag<string>();


        public void Add(string token)
        {
            if (!concurrentBag.Contains(token))
                concurrentBag.Add(token);

        }

        public IEnumerable<string> GetAll()
        {
            return concurrentBag.AsEnumerable();
        }
    }
}
