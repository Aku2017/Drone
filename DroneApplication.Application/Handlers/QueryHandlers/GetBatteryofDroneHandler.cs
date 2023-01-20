using DroneApplication.Application.Queries;
using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using DroneApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Application.Handlers.QueryHandlers
{
    public class GetBatteryofDroneHandler : IRequestHandler<GetDroneBatteryQuery, DroneBatteryResponse>
    {
        private readonly IDroneRepository droneRepository;

        public GetBatteryofDroneHandler(IDroneRepository _droneRepository)
        {
            this.droneRepository = _droneRepository;
        }

        public async Task<DroneBatteryResponse> Handle(GetDroneBatteryQuery request, CancellationToken cancellationToken)
        {
    
            Drone drone = droneRepository.GetBatteryofDrone(request.SerialNumber).Result.FirstOrDefault();
            var droneResponse = new DroneBatteryResponse();
            if (drone != null)
            {
                droneResponse.BatteryCapacity = drone.BatteryCapacity;
                droneResponse.SerialNumber = drone.SerialNumber;

            }
            return droneResponse;
        }
    }
}
