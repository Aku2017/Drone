using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Application.Responses
{
    public class DroneBatteryResponse
    {
        public string  SerialNumber { get; set; }

        public int BatteryCapacity { get; set; }
    }
}
