using AutoMapper;
using DroneApplication.Application.Commands.Create;
using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Application.Mapper
{
  public class MedicationMappingProfile : Profile
    {
        public MedicationMappingProfile()
        {
            CreateMap<Medication, MedicationResponse>().ReverseMap();
            CreateMap<Medication, CreateMedicationCommand>().ReverseMap();
        }
    }
}
