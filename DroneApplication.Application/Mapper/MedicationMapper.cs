using AutoMapper;
using DroneApplication.Application.Mapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApp.Application.Mapper
{
  public  class MedicationMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
                cfg.AddProfile<MedicationMappingProfile>();

            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper = Lazy.Value;

    }
}
