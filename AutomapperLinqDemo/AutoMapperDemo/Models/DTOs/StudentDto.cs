using AutoMapperDemo.Models.Entities;

namespace AutoMapperDemo.Models.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<CourseDto> Courses { get; set; }
    }
}
