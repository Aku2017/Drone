using DroneApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Application.Queries
{
 public class GetAllDroneQuery: IRequest<List<Drone>>
    {
        public string? SerialNumber { get; set; }
        public string? DroneName { get; set; }
        public int? BatteryCapacity { get; set; }
        public ModelType? ModelType { get; set; }
        public int? WeightLimit { get; set; }
        public State? Stete { get; set; }
        public Guid? Id { get; set; }
        public GetAllDroneQuery()
        {

        }
    }
}
