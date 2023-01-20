using DroneApplication.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Infrastructure.Repository.DatabaseContext
{
  public  class DroneDbContext : DbContext
    {
        public DroneDbContext(DbContextOptions<DroneDbContext> options) : base (options)
        {
           Database.EnsureCreated();//using Microsoft EntityFramework
        }
       
        public DbSet<Drone> Drones { get; set; }

        public DbSet<Medication> Medications { get; set; }
    }
}
