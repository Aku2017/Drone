using DroneApplication.Application.Responses;
using DroneApplication.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Application.Queries
{
   public class GetAllMedicationQuery : IRequest<List<MedicationResponse>>
    {
        public virtual Guid DroneID { get; set; }

        public virtual string DroneSerialNumber { get; set; }

        public GetAllMedicationQuery(string droneSerialNumber)
        {
            this.DroneSerialNumber = droneSerialNumber;
        }
    }
}
