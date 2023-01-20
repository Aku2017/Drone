using DroneApplication.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DroneApplication.Domain.Entities
{
   public class Drone: BaseEntity
    {
        [StringLength(100)]
        public virtual string SerialNumber { get; set; }
        public virtual string DroneName { get; set; }
        public virtual int BatteryCapacity { get; set; }
        public virtual ModelType ModelType { get; set; }
        public virtual int WeightLimit { get; set; }
        public virtual State State { get; set; }
        public virtual IList<Medication> Medications { get; set; }

        public Drone()
        {
            this.Medications = new List<Medication>();
        }
    }
}
