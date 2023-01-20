using DroneApplication.Application.Queries;
using DroneApplication.Application.Responses;
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
    public class GetAllMedicationHandler : IRequestHandler<GetAllMedicationQuery, List<MedicationResponse>>
    {
      //  private readonly IBaseRepo<Medication> medicationRepo;
        private readonly IMedicationRepository _medicationRepository;
        private readonly IDroneRepository droneRepository;
        public GetAllMedicationHandler(IMedicationRepository _medicationRepo, IDroneRepository _droneRepository)
        {
            this._medicationRepository = _medicationRepo;
            this.droneRepository = _droneRepository;
        }
        public async Task<List<MedicationResponse>> Handle(GetAllMedicationQuery request, CancellationToken cancellationToken)
        {
           
            List<Medication> MedicationsinDrone =   (List<Medication>)await _medicationRepository.GetMedicationsByDroneSerialNumber(request.DroneSerialNumber);
            List<MedicationResponse> medicationResponses = new List<MedicationResponse>();
            foreach (var item in MedicationsinDrone)
            {
                var medResponse = new MedicationResponse()
                {
                    Weight = item.Weight,
                    Code = item.Code,
                    DroneSerialNumber = item.Drone.SerialNumber,
                    MedicationName = item.MedicationName,
                    ImagePath = item.ImagePath,
                    
                };
                medResponse.StatusMessage = "Ok";
                medicationResponses.Add(medResponse);
            }
            

            return medicationResponses;
        }

       
    }
}
