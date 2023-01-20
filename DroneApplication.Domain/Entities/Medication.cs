using DroneApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DroneApplication.Domain.Entities
{
   public class Medication: BaseEntity
    {
        public virtual string? MedicationName { get; set; }
        public virtual int Weight { get; set; }
        public virtual string? Code { get; set; }
        public virtual string? ImagePath { get; set; }
        public virtual Drone? Drone { get; set; } 


        
    }
}
