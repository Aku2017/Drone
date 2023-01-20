using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Application.Commands.Create
{
  public  class CreateMedicationCommand : IRequest<MedicationResponse>
    {
            public virtual string? MedicationName { get; set; }
            public virtual int? Weight { get; set; }
            public virtual string? Code { get; set; }
            public virtual string? ImagePath { get; set; }
           public virtual string DroneSerialNumber { get; set; }

    }
}
