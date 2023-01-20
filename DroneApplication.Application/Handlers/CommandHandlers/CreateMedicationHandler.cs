using DroneApplication.Application.Commands.Create;
using DroneApplication.Application.Mapper;
using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using DroneApplication.Domain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace DroneApplication.Application.Handlers.CommandHandlers
{
   public class CreateMedicationHandler: IRequestHandler<CreateMedicationCommand, MedicationResponse>
    {
        private readonly IBaseRepo<Medication> medicationRepo;
        private readonly IDroneRepository droneRepository;
        private readonly IValidator<Medication> validator;

        public CreateMedicationHandler(IBaseRepo<Medication> _medicationRepo, IDroneRepository _droneRepo, IValidator<Medication>Validator)
        {
            medicationRepo = _medicationRepo;
            droneRepository = _droneRepo;
            validator = Validator;
        }

        public async Task<MedicationResponse> Handle(CreateMedicationCommand request, CancellationToken cancellationToken)
        {
            var newMedicationResponse = new MedicationResponse();
            Drone drone = droneRepository.GetAllDrones().Result.Where(a => a.SerialNumber == request.DroneSerialNumber).FirstOrDefault();
           
            bool CheckifMedicationhasbeenLoaded = medicationRepo.GetAllAsync().Result.Any(x => x.Code == request.Code);

            if (drone == null)
            {
                throw new ApplicationException("Drone not found in Database, Check serial number");
            }
            if (CheckifMedicationhasbeenLoaded)
            {
                throw new ApplicationException("Medication already exists, Check code and Try again");
            }
            else
            {
                await LoadDroneWithMedications(request, newMedicationResponse, drone);
            }
             return newMedicationResponse;
        }

        private async Task LoadDroneWithMedications(CreateMedicationCommand request, MedicationResponse newMedicationResponse, Drone drone)
        {
            var medication = new Medication()
            {
                Drone = drone,
                Weight = (int)request.Weight,
                ImagePath = request.ImagePath,
                MedicationName = request.MedicationName,
                Code = request.Code,
            };


            var results = validator.Validate(medication);
            if (results.IsValid)
            {
                drone.State = State.Loading;
                await MapMedicationsResponse(drone, newMedicationResponse, medication);// var newMedicationResponse = new MedicationResponse();
                await droneRepository.UpdateAsync(drone);

            }
            else
            {
                newMedicationResponse.StatusMessage = results.Errors[0].ErrorMessage;
                throw new ApplicationException("Medication Name and Code not in right format");

            }

        }

        private async Task MapMedicationsResponse(Drone drone, MedicationResponse newMedicationResponse, Medication medication)
        {
            if (drone.BatteryCapacity < 25)
            {
                drone.State = State.Idle;
                newMedicationResponse.StatusMessage = "Low Battery Capacity";
            }
            else if ((drone.WeightLimit + medication.Weight) >= 500)
            {
                drone.State = State.Loaded;
                newMedicationResponse.StatusMessage = "Drone Weight Limit Exceeded";
            }
            else
            {
                drone.WeightLimit += medication.Weight;
                drone.Medications.Add(medication);            
                var newmedication = await medicationRepo.AddAsync(medication);
                newMedicationResponse.MedicationName = medication.MedicationName;
                newMedicationResponse.StatusMessage = "Successfully Loaded Drone with Medication";
                newMedicationResponse.Code = medication.Code;
                newMedicationResponse.DroneSerialNumber = drone.SerialNumber;
                newMedicationResponse.ImagePath = medication.ImagePath;
                newMedicationResponse.Weight = medication.Weight;


            }
        }
    }
}
