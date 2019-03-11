using System.Linq;
using AutoMapper;
using AutoMapperRepro.Models;

namespace AutoMapperRepro.Config
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
        {
            CreateMap<Comment, Comment.ViewDto>();
            CreateMap<Post, Post.ViewDto>().ForMember(dto => dto.LastComment, cfg => cfg.MapFrom(model => model.Comments.LastOrDefault()));
            CreateMap<User, User.ViewDto>();
        }
    }
}
