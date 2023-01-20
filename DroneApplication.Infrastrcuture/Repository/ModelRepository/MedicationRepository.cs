using DroneApplication.Domain.Entities;
using DroneApplication.Domain.Interfaces;
using DroneApplication.Infrastructure.Repository.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Infrastructure.Repository.ModelRepository
{
   public class MedicationRepository : BaseRepo<Medication>, IMedicationRepository
    {
        public MedicationRepository(DroneDbContext droneDbContext) : base(droneDbContext)
        {

        }

        public async Task<Medication> GetDroneById(Guid id)
        {
            return await droneDbContext.Medications.Where(a => a.Id == id).FirstOrDefaultAsync();
        }


        public async Task<List<Medication>> GetMedicationsByDroneIds(Guid Id)
        {
            var result = droneDbContext.Medications.Where(a => a.Drone.Id == Id).ToListAsync();
            return await result;

        }

        public async Task<List<Medication>> GetMedicationsByDroneSerialNumber(string droneSerialNo)
        {
            var result = droneDbContext.Medications.Where(a => a.Drone.SerialNumber == droneSerialNo).ToListAsync();
            return await result;

        }

    }

}

