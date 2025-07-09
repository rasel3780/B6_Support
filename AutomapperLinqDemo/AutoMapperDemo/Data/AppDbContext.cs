using AutoMapperDemo.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace AutoMapperDemo.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }





        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // join configuration 
            modelBuilder.Entity<Enrollment>()
                .HasKey(e => new { e.StudentId, e.CourseId });

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Student)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.StudentId);

            modelBuilder.Entity<Enrollment>()
                .HasOne(e => e.Course)
                .WithMany(s => s.Enrollments)
                .HasForeignKey(e => e.CourseId);

            // Seeding 
            var users = new List<User>
            {
                new User { Id = 1, UserName = "James", Email = "james@gmail.com", IsAdmin = true, Salary=35500 },
                new User { Id = 2, UserName = "Anna", Email = "anna@gmail.com", IsAdmin = false, Salary=33500 },
                new User { Id = 3, UserName = "Robert", Email = "robert@gmail.com", IsAdmin = false, Salary=55500 },
                new User { Id = 4, UserName = "Maria", Email = "maria@gmail.com", IsAdmin = true,Salary=85500 },
                new User { Id = 5, UserName = "David", Email = "david@gmail.com", IsAdmin = false, Salary=55500 },
                new User { Id = 6, UserName = "Sophia", Email = "sophia@gmail.com", IsAdmin = false,Salary=75500 },
                new User { Id = 7, UserName = "Michael", Email = "michael@gmail.com", IsAdmin = false, Salary=39500 },
                new User { Id = 8, UserName = "Emma", Email = "emma@gmail.com", IsAdmin = false, Salary=33500 },
                new User { Id = 9, UserName = "Daniel", Email = "daniel@gmail.com", IsAdmin = true, Salary=54300 },
                new User { Id = 10, UserName = "Olivia", Email = "olivia@gmail.com", IsAdmin = false, Salary=32100 }
            };
            modelBuilder.Entity<User>().HasData(users);


            var profiles = new List<UserProfile>
            {
                new UserProfile { Id = 1, UserId = 1, FullName = "James Bond", DateOfBirth = new DateTime(1990, 5, 15) },
                new UserProfile { Id = 2, UserId = 2, FullName = "Anna Smith", DateOfBirth = new DateTime(1988, 3, 22) },
                new UserProfile { Id = 3, UserId = 3, FullName = "Robert Johnson", DateOfBirth = new DateTime(1995, 7, 10) },
                new UserProfile { Id = 4, UserId = 4, FullName = "Maria Garcia", DateOfBirth = new DateTime(1980, 11, 30) },
                new UserProfile { Id = 5, UserId = 5, FullName = "David Lee", DateOfBirth = new DateTime(1992, 1, 18) },
                new UserProfile { Id = 6, UserId = 6, FullName = "Sophia Kim", DateOfBirth = new DateTime(1999, 9, 5) },
                new UserProfile { Id = 7, UserId = 7, FullName = "Michael Brown", DateOfBirth = new DateTime(1985, 4, 12) },
                new UserProfile { Id = 8, UserId = 8, FullName = "Emma Taylor", DateOfBirth = new DateTime(2000, 6, 25) },
                new UserProfile { Id = 9, UserId = 9, FullName = "Daniel Wilson", DateOfBirth = new DateTime(1993, 12, 1) },
                new UserProfile { Id = 10, UserId = 10, FullName = "Olivia Moore", DateOfBirth = new DateTime(1997, 2, 14) }
            };

            modelBuilder.Entity<UserProfile>().HasData(profiles);

            var categories = new List<Category>
            {
                new Category { Id = 1, Name = "Electronics" },
                new Category { Id = 2, Name = "Books" },
                new Category { Id = 3, Name = "Clothing" },
                new Category { Id = 4, Name = "Home Appliances" },
                new Category { Id = 5, Name = "Toys" },
                new Category { Id = 6, Name = "Sports" },
                new Category { Id = 7, Name = "Beauty" },
                new Category { Id = 8, Name = "Furniture" },
                new Category { Id = 9, Name = "Games" },
                new Category { Id = 10, Name = "Music" }
            };

            modelBuilder.Entity<Category>().HasData(categories);

            var products = new List<Product>
            {
                new Product { Id = 1, Name = "Laptop", CategoryId = 1 },
                new Product { Id = 2, Name = "Smartphone", CategoryId = 1 },
                new Product { Id = 3, Name = "C# Programming Book", CategoryId = 2 },
                new Product { Id = 4, Name = "ASP.NET Core Guide", CategoryId = 2 },
                new Product { Id = 5, Name = "T-Shirt", CategoryId = 3 },
                new Product { Id = 6, Name = "Jeans", CategoryId = 3 },
                new Product { Id = 7, Name = "Microwave", CategoryId = 4 },
                new Product { Id = 8, Name = "Blender", CategoryId = 4 },
                new Product { Id = 9, Name = "Action Figure", CategoryId = 5 },
                new Product { Id = 10, Name = "Board Game", CategoryId = 9 },
                new Product { Id = 11, Name = "Football", CategoryId = 6 },
                new Product { Id = 12, Name = "Shampoo", CategoryId = 7 },
                new Product { Id = 13, Name = "Sofa", CategoryId = 8 },
                new Product { Id = 14, Name = "Guitar", CategoryId = 10 },
                new Product { Id = 15, Name = "Headphones", CategoryId = 1 }
            };

            modelBuilder.Entity<Product>().HasData(products);


            var students = new List<Student>
            {
                new Student { Id = 1, Name = "Araf" },
                new Student { Id = 2, Name = "Pranto" },
                new Student { Id = 3, Name = "Rahim" },
                new Student { Id = 4, Name = "Karim" },
                new Student { Id = 5, Name = "Sadia" },
                new Student { Id = 6, Name = "Tania" },
                new Student { Id = 7, Name = "Mehedi" },
                new Student { Id = 8, Name = "Farhan" },
                new Student { Id = 9, Name = "Nafisa" },
                new Student { Id = 10, Name = "Tamim" }
            };

            modelBuilder.Entity<Student>().HasData(students);

            var courses = new List<Course>
            {
                new Course { Id = 1, Title = "C#" },
                new Course { Id = 2, Title = "Database" },
                new Course { Id = 3, Title = "Python" },
                new Course { Id = 4, Title = "Web Development" },
                new Course { Id = 5, Title = "Java" },
                new Course { Id = 6, Title = "Machine Learning" },
                new Course { Id = 7, Title = "Design Patterns" },
                new Course { Id = 8, Title = "Networking" },
                new Course { Id = 9, Title = "Operating Systems" },
                new Course { Id = 10, Title = "Algorithms" }
            };

            modelBuilder.Entity<Course>().HasData(courses);

            var enrollments = new List<Enrollment>
            {
                new Enrollment { StudentId = 1, CourseId = 1 },
                new Enrollment { StudentId = 1, CourseId = 2 },
                new Enrollment { StudentId = 2, CourseId = 2 },
                new Enrollment { StudentId = 2, CourseId = 3 },
                new Enrollment { StudentId = 3, CourseId = 1 },
                new Enrollment { StudentId = 3, CourseId = 4 },
                new Enrollment { StudentId = 4, CourseId = 5 },
                new Enrollment { StudentId = 4, CourseId = 6 },
                new Enrollment { StudentId = 5, CourseId = 7 },
                new Enrollment { StudentId = 5, CourseId = 8 },
                new Enrollment { StudentId = 6, CourseId = 9 },
                new Enrollment { StudentId = 6, CourseId = 10 },
                new Enrollment { StudentId = 7, CourseId = 1 },
                new Enrollment { StudentId = 7, CourseId = 3 },
                new Enrollment { StudentId = 8, CourseId = 2 },
                new Enrollment { StudentId = 8, CourseId = 5 },
                new Enrollment { StudentId = 9, CourseId = 4 },
                new Enrollment { StudentId = 9, CourseId = 6 },
                new Enrollment { StudentId = 10, CourseId = 7 },
                new Enrollment { StudentId = 10, CourseId = 9 }
            };

            modelBuilder.Entity<Enrollment>().HasData(enrollments);


        }
    }
}
