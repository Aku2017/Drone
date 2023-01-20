using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DroneApplication.Application.Mapper
{
   public class DroneMapper
    {
        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() =>
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
               
                cfg.AddProfile<DroneMappingProfile>();

            });
            var mapper = config.CreateMapper();
            return mapper;
        });

        public static IMapper Mapper = Lazy.Value;
    }
}
