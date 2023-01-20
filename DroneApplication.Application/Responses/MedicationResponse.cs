using DroneApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DroneApplication.Application.Responses
{
  public  class MedicationResponse
    {
        public string? MedicationName { get; set; }
        public int? Weight { get; set; }
        public  string? Code { get; set; }
        public virtual string? ImagePath { get; set; }
      //  public virtual Drone? Drone { get; set; }

        public virtual string DroneSerialNumber { get; set; }
        public virtual string? StatusMessage { get; set; }
    }
}
