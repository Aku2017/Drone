using DroneApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Application.Responses
{
   public class DroneResponse
    {
        public  string? SerialNumber { get; set; }
        public string? DroneName { get; set; }
        public int? BatteryCapacity { get; set; }
        public  string? ModelType { get; set; }
        public  int WeightLimit { get; set; }
        public string State { get; set; }
        public IList<Medication>? Medications { get; set; }
    }
}
