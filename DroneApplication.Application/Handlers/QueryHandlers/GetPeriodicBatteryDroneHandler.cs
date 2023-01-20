using AutoMapper.Execution;
using DroneApplication.Application.Queries;
using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using DroneApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace DroneApplication.Application.Handlers.QueryHandlers
{
    public class GetPeriodicBatteryDroneHandler : IRequestHandler<GetAllDroneBatteryQuery,List<DroneBatteryResponse>>
    {
        private readonly IDroneRepository _droneRepository;
        private List<DroneBatteryResponse> _responses;
        private  System.Timers.Timer timer;
        private List<Drone> drones;
        public GetPeriodicBatteryDroneHandler(IDroneRepository droneRepository) 
        {
            this._droneRepository = droneRepository;
        }

        public async Task<List<DroneBatteryResponse>> Handle(GetAllDroneBatteryQuery request, CancellationToken cancellationToken)
        {
            _responses = new List<DroneBatteryResponse>();
            drones = _droneRepository.GetAllDrones().Result.ToList();
            Timer_Elapsed();
            return _responses; ;
        }

        private void Timer_Elapsed()
        {
            foreach (var item in drones)
            {
                var droneBatteryResponse = new DroneBatteryResponse()
                {
                    SerialNumber = item.SerialNumber,
                    BatteryCapacity= item.BatteryCapacity,
                };
                _responses.Add(droneBatteryResponse);
            }
           // throw new NotImplementedException();
        }
    }
}
