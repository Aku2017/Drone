using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Application.Queries
{
    public class GetDroneBatteryQuery : IRequest<DroneBatteryResponse>
    {
        public string? SerialNumber { get; set; }
        public string? DroneName { get; set; }
        public int? BatteryCapacity { get; set; }
        public ModelType? ModelType { get; set; }
        public int? WeightLimit { get; set; }
        public State? Stete { get; set; }
        public Guid? Id { get; set; }
        public GetDroneBatteryQuery(string? SerialNumber)
        {
            this.SerialNumber = SerialNumber;
        }

        public GetDroneBatteryQuery()
        {

        }
    }
}
