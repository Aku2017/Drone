using DroneApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace DroneApplication.Application.DroneValidatior
{
    public class DroneValidator : AbstractValidator<Drone>
    {
        public string serialNumber { get; set; }
        public DroneValidator()
        {
            
            BuildRules();

        }

        public void BuildRules()
        {
            RuleFor(Drone => Drone.SerialNumber).NotEmpty().Length(0, 100);

        }
    }
}
