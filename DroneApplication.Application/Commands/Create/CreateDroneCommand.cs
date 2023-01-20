using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Application.Commands.Create
{
   public class CreateDroneCommand : IRequest<DroneResponse>
    {
        public string? SerialNumber { get; set; }
        public string? DroneName { get; set; }
        public int? BatteryCapacity { get; set; }
        public string ModelType { get; set; }
        public int? WeightLimit { get; set; }
        public string State { get; set; }
        
    }
}
