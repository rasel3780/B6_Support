using AutoMapperDemo.Models.DTOs;

namespace AutoMapperDemo.Models
{
    public class IndexViewModel
    {
        public int TotalStudents { get; set; }
        public int AdminCount { get; set; }

        public decimal MaxSalary { get; set; }
        public decimal MinSalary { get; set; }
        public decimal AvgSalary { get; set; }
        public bool HasAtLeastOneProduct { get; set; }
        public bool IsCourseExist { get; set; }
        public List<ProductDto> ProductsByCategory { get; set; }
        public List<StudentDto> AllStudentWithCourse { get; set; }

    }
}
