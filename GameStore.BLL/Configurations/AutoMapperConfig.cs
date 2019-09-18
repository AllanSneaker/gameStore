using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.DAL.Entity.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GameStore.BLL.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Game, GameDto>().ReverseMap();
        }

        public static void Map(IServiceCollection services)
        {
            var mappingConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfiles(new Profile[] { new AutoMapperConfig() });
            });
            IMapper mapper = mappingConfiguration.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
