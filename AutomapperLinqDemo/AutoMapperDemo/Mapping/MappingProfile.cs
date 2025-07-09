using AutoMapper;
using AutoMapperDemo.Models.DTOs;
using AutoMapperDemo.Models.Entities;
using System.Net.Cache;

namespace AutoMapperDemo.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                 .ReverseMap();
                

            CreateMap<UserProfile, UserProfileDto>()
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => CalculateAge(src.DateOfBirth)))
                .ReverseMap()
                .ForMember(dest => dest.User, opt => opt.Ignore());

            CreateMap<Category, CategoryDto>()
                .ReverseMap();

            CreateMap<Product, ProductDto>()
                .ReverseMap()
                .ForMember(dest => dest.Category, opt => opt.Ignore());

            CreateMap<Course, CourseDto>();
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.Courses,
                           opt => opt.MapFrom(src => src.Enrollments.Select(e => e.Course)))
                .ReverseMap()
                .ForMember(dest => dest.Enrollments, opt => opt.Ignore());
        }

        private int CalculateAge(DateTime dob) 
        {
            var today = DateTime.Now;
            var age = today.Year - dob.Year;
            return age;
        }
    }
}
