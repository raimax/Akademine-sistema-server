using AutoMapper;
using Server.Data;
using Server.Models;

namespace Server.Configurations
{
    public class MapperInitializer : Profile
    {
        public MapperInitializer()
        {
            CreateMap<User, RegisterDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<Group, CreateGroupDTO>().ReverseMap();
        }
    }
}
