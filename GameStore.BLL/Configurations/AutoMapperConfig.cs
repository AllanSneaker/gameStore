using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.DAL.Entity.Models;
using GameStore.DAL.Entity.Models.Game;

namespace GameStore.BLL.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Game, GameDto>().ReverseMap();
            CreateMap<Comment, CommentDto>().ReverseMap();
        }
    }
}
