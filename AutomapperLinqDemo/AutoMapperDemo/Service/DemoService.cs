using AutoMapper;
using AutoMapper.QueryableExtensions;
using AutoMapperDemo.Data;
using AutoMapperDemo.Models.DTOs;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperDemo.Service
{
    public class DemoService
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DemoService(AppDbContext context, IMapper mapper)
        {
            _dbContext = context;
            _mapper = mapper;
        }

        //Where + Count
        public async Task<int> CountAdmin()
        {
            var result = await _dbContext.Users
                .Where(u => u.IsAdmin)
                .CountAsync() ;
           
            return result;
        }

        //Find students enrolled in a specific course
        public async Task<List<StudentDto>> GetStudentsInCourse(string courseTitle)
        {
            return await _dbContext.Students
                .Where(s => s.Enrollments.Any(e => e.Course.Title == courseTitle))
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // Get all students with course
        public async Task<List<StudentDto>> GetAllStudentWithCourse()
        {
            return await _dbContext.Students
                .Include(s => s.Enrollments)
                .ThenInclude(e=>e.Course)
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
        }

        // Group By
        public async Task<List<StudentsByCourseDto>> GetStudentsGroupByCourse()
        {
            return await _dbContext.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course)
                .GroupBy(e => e.Course.Title)
                .Select(g => new StudentsByCourseDto
                {
                    CourseTitle = g.Key,
                    StudentsName = g.Select(e => e.Student.Name).ToList()

                })
                .ToListAsync();
        }


        // Count total student 
        public async Task<int> CountTotalStudent()
        {
            return await _dbContext.Students.CountAsync();
        }

        // Get Student Order By
        public async Task<StudentDto> GetFirstStudent()
        {
            return await _dbContext.Students
                .OrderBy(s => s.Name)
                .ProjectTo<StudentDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();
        }


        public async Task<decimal> GetMaxSalary()
        {
            return await _dbContext.Users
                .MaxAsync(u => u.Salary);
        }

        public async Task<decimal> GetMinSalary()
        {
            return await _dbContext.Users
                .MinAsync(u => u.Salary);
        }

        public async Task<decimal> GetAvgSalary()
        {
            return await _dbContext.Users
                .AverageAsync(u => u.Salary);
        }


        public async Task<bool> HasAtleastOneProduct()
        {
            return await _dbContext.Products.AnyAsync();
        }


        public async Task<bool> IsCourseExist()
        {
            return await _dbContext.Courses
                .AnyAsync(c=>c.Title=="Go");
        }

        //Join 
        public async Task<List<ProductDto>> GetProductInCategory(string categoryName)
        {
            var query = from p in _dbContext.Products
                        join c in _dbContext.Categories on p.CategoryId equals c.Id
                        where c.Name == categoryName
                        select p;

            return await query.ProjectTo<ProductDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

        }




    }
}
