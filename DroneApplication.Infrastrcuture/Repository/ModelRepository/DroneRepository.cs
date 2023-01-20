using DroneApplication.Domain.Entities;
using DroneApplication.Domain.Interfaces;
using DroneApplication.Infrastructure.Repository.DatabaseContext;
using DroneApplication.Infrastructure.Repository.ModelRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Infrastructure.Repository.ModelRepository
{
    public class DroneRepository : BaseRepo<Drone>, IDroneRepository
    {
        public DroneRepository(DroneDbContext droneDbContext): base(droneDbContext)
        {

        }

        public async Task<IList<Drone>> GetAllIdleDrones()
        {
            return await droneDbContext.Drones.Where(a => a.State > 0 ).ToListAsync();
        }

        public async Task<List<Drone>> GetAllDrones()
        {
            return await droneDbContext.Drones.ToListAsync();
        }

        public async Task<List<Drone>> GetDronesAvailability()
        {
            return await droneDbContext.Drones.Where(a=>a.BatteryCapacity>25 && a.WeightLimit < 500).ToListAsync();
        }

        public async Task<List<Drone>> GetBatteryofDrone(string serialnumber)
        {
            return await droneDbContext.Drones.Where(a => a.SerialNumber == serialnumber).ToListAsync();
        }
        public async Task<Drone> GetDroneById(Guid id)
        {
            return await droneDbContext.Drones.Where(a => a.Id == id).Include(b => b.Medications).FirstOrDefaultAsync();
        }
    }
}
