using AutoMapper;
using GameStore.BLL.DTO;
using GameStore.PL.Models;

namespace GameStore.PL.Configurations
{
    public class AutoMapperConfigPL : Profile
    {
        public AutoMapperConfigPL()
        {
            CreateMap<CommentDto, CommentModel>()
                .ForMember(dst => dst.Game, map => map.MapFrom(src => src.Game.Name))
                .ForMember(dst => dst.Parent, map => map.MapFrom(src => src.Parent.Name));

            CreateMap<AddCommentModel, CommentDto>().ReverseMap();
        }

    }
}
