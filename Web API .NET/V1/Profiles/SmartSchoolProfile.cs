using AutoMapper;
using Web_API_.NET.V1.Dtos;
using Web_API_.NET.Models;
using Web_API_.NET.Helpers;

namespace Web_API_.NET.V1.Profiles.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            // Student
            CreateMap<Student, StudentDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Lastname}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge())
                );
            
            CreateMap<StudentDto, Student>();
            CreateMap<Student, RegisterStudentDto>().ReverseMap();

            //Teacher
            CreateMap<Teacher, TeacherDto>()
                .ForMember(
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.Name} {src.Lastname}")
                )
                .ForMember(
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.BirthDate.GetCurrentAge())
                );
            
            CreateMap<TeacherDto, Teacher>();
            CreateMap<Teacher, RegisterTeacherDto>().ReverseMap();
        }
    }
}