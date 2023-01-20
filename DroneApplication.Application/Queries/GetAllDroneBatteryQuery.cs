using DroneApplication.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Application.Queries
{
    public class GetAllDroneBatteryQuery: IRequest<List<DroneBatteryResponse>>
    {
        public string DroneSerialNumber { get; set; }
        public int BatteryLevel { get; set;}
    }
}
