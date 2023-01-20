using DroneApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Domain.Interfaces
{
  public interface IMedicationRepository: IBaseRepo<Medication>
    {
        Task<List<Medication>> GetMedicationsByDroneIds(Guid Id);

        Task<List<Medication>> GetMedicationsByDroneSerialNumber(string droneSerialNo);
    }
}
