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
            CreateMap<User, CreateLecturerDTO>().ReverseMap();
            CreateMap<User, LecturerDTO>().ReverseMap();
            CreateMap<User, StudentDTO>().ReverseMap();
            CreateMap<Group, CreateGroupDTO>().ReverseMap();
            CreateMap<Group, GroupDTO>().ReverseMap();
            CreateMap<Subject, CreateSubjectDTO>().ReverseMap();
            CreateMap<Subject, SubjectDTO>().ReverseMap();
            CreateMap<LecturerSubject, AssignSubjectDTO>().ReverseMap();
            CreateMap<StudentGroup, AssignGroupDTO>().ReverseMap();
            CreateMap<GroupSubject, AssignGroupSubjectAttributes>().ReverseMap();
            CreateMap<GroupSubject, GroupSubjectDTO>().ReverseMap();
            CreateMap<GroupSubject, RemoveGroupSubjectDTO>().ReverseMap();
            CreateMap<GroupSubject, RemoveGroupSubjectAttributes>().ReverseMap();
            CreateMap<StudentGrade, AddGradeDTO>().ReverseMap();
        }
    }
}
