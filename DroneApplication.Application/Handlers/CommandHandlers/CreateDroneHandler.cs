using DroneApplication.Application.Commands.Create;
using DroneApplication.Application.Converters;
using DroneApplication.Application.Mapper;
using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using DroneApplication.Domain.Interfaces;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DroneApplication.Application.Handlers.CommandHandlers
{
 public  class CreateDroneHandler: IRequestHandler<CreateDroneCommand, DroneResponse>
    {
        private readonly IDroneRepository droneRepository;
        private readonly IValidator<Drone> Validator;
        public CreateDroneHandler(IDroneRepository _droneRepository, IValidator<Drone> validator)
        {
            droneRepository = _droneRepository;
            Validator = validator;  
        }

        public async Task<DroneResponse> Handle(CreateDroneCommand request, CancellationToken cancellationToken)
        {
            
            DroneResponse newDroneResponse;
            //checking if serial no exists in Database
            bool checkifSerialNoExists = droneRepository.GetAllAsync().Result.Any(a => a.SerialNumber == request.SerialNumber);
          
            if (checkifSerialNoExists)
            {
                throw new ApplicationException("Serial Number Exists, Please try another one");
            }
            else
            {
                //   var droneEntity = DroneMapper.Mapper.Map<Drone>(request);
                var droneEntity = new Drone()
                {
                    BatteryCapacity = (int)request.BatteryCapacity,
                    DroneName = request.DroneName,
                    SerialNumber = request.SerialNumber,
                    ModelType = (ModelType)EnumUtilConverter.convertStringValuestoModelTypeEnum(request.ModelType),
                    State = (State)EnumUtilConverter.convertStringValuestoStateTypeEnum(request.State)
                };
                var results = Validator.Validate(droneEntity);

                if (droneEntity == null || (!results.IsValid))
                {
                    throw new ApplicationException( "Serial Number exceeds max length");
                }

                else 
                {
                    var newDrone = await droneRepository.AddAsync(droneEntity);
                    newDroneResponse = DroneMapper.Mapper.Map<DroneResponse>(droneEntity);
                    newDroneResponse.State = EnumUtilConverter.GetDescription(droneEntity.State);
                    newDroneResponse.ModelType = EnumUtilConverter.GetDescription(droneEntity.ModelType);

                }
            }
            return newDroneResponse;
        }
    }
}
