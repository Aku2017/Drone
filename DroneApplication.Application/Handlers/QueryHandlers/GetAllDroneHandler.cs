using DroneApplication.Application.Queries;
using DroneApplication.Domain.Entities;
using DroneApplication.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneApp.Application.Handlers.QueryHandlers
{
    public class GetAllDroneHandler : IRequestHandler<GetAllDroneQuery, List<Drone>>
    {
        private readonly IDroneRepository droneRepository;
        public GetAllDroneHandler(IDroneRepository _droneRepository)
        {
            droneRepository = _droneRepository;
        }
        public async Task<List<Drone>> Handle(GetAllDroneQuery request, CancellationToken cancellationToken)
        {
                return await droneRepository.GetDronesAvailability();
         
        }
        
    }
}
