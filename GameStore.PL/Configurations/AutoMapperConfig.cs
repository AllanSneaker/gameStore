using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.PL.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameStore.PL.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<CommentModel, CommentDto>().ReverseMap()
                .ForMember(dst => dst.Game, map => map.MapFrom(src => src.Game.Name));
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
