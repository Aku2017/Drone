using DroneApplication.Application.Handlers.CommandHandlers;
using DroneApplication.Domain.Interfaces;
using DroneApplication.Infrastructure.Repository.DatabaseContext;
using DroneApplication.Infrastructure.Repository.ModelRepository;
using DroneApplication.Application.Handlers.CommandHandlers;
using DroneApplication.Domain.Interfaces;
using DroneApplication.Infrastructure.Repository.DatabaseContext;
using DroneApplication.Infrastructure.Repository.ModelRepository;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using FluentValidation;
using DroneApplication.Application.Validation;
using DroneApplication.Domain.Entities;
using DroneApplication.Application.DroneValidatior;
using DroneApplication.Application.Utility.LoggerService;

namespace DroneApplication
{
    public class Startup
    {
        private System.Timers.Timer timer;
        private IServiceCollection _serviceCollections;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _serviceCollections = services;
            services.AddControllers();


            services.AddDbContext<DroneDbContext>(
                m => m.UseSqlite(Configuration.GetConnectionString("DroneDB")), ServiceLifetime.Singleton);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Drone.API", Version = "v1" });
            });
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateDroneHandler).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IBaseRepo<>), typeof(BaseRepo<>));
            services.AddTransient<IDroneRepository, DroneRepository>();
            services.AddTransient<IMedicationRepository, MedicationRepository>();
            services.AddScoped<IValidator<Drone>, DroneValidator>();
            services.AddScoped<IValidator<Medication>, MedicationValidator>();
            CheckAllDronesBatteryLevel(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Drone.API v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void CheckAllDronesBatteryLevel(IServiceCollection services)
        {
            timer = new System.Timers.Timer(2000);
            timer.Elapsed += Timer_Elapsed;
            timer.AutoReset = true;
            timer.Enabled= true;
            timer.Stop();
            timer.Dispose();
           // Action readBattery = new Action(()=>ReadBatteryinDrones(services));
           // Task batteryTask = new Task(readBattery);
           // batteryTask.Start();
            
        }

        private void Timer_Elapsed(object? sender, System.Timers.ElapsedEventArgs e)
        {
            // throw new NotImplementedException();
            ReadBatteryinDrones(_serviceCollections);
            Log("The Elapsed event was raised at {0:HH:mm:ss.fff}"+ e.SignalTime);
        }

        private  void ReadBatteryinDrones(IServiceCollection services)
        {
            var IdroneRepository = services.BuildServiceProvider().GetService<IDroneRepository>();
            var drone = IdroneRepository.GetAllDrones().Result.FirstOrDefault();
            
           // Console.WriteLine("michael");
            //Console.ReadKey();
        }

        public void Log(string message)
        {
            string filePath = @"C:\Users\Mike\Documents\LoggerInfo.txt";
            using (StreamWriter streamWriter = new StreamWriter(filePath))
            {
                streamWriter.WriteLine(message);
                streamWriter.Close();
            }
        }
    }
}
