using DroneApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DroneApplication.Domain.Interfaces
{
   public interface IDroneRepository: IBaseRepo<Drone>
    {
        Task<Drone> GetDroneById(Guid id);
        Task<IList<Drone>> GetAllIdleDrones();
        Task<List<Drone>> GetDronesAvailability();
        Task<List<Drone>> GetBatteryofDrone(string serialnumber);
        Task<List<Drone>> GetAllDrones();
       
    }
}
