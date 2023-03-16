using KusysDemo.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusysDemo.DAL
{
    public class KusysContext : DbContext
    {
        public KusysContext(DbContextOptions<KusysContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasKey(x => x.StudentId);
            modelBuilder.Entity<Course>().HasKey(x => x.CourseId);
            modelBuilder.Entity<Role>().HasKey(x => x.RoleId);
            modelBuilder.Entity<User>().HasKey(x => x.UserId);
            modelBuilder.Entity<UserRole>().HasKey(x => x.Id);
            modelBuilder.Entity<StudentCourse>().HasKey(x => x.Id);
            this.SeedDatas(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<StudentCourse> StudentCourses { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        private void SeedDatas(ModelBuilder builder)
        {
            this.SeedStudents(builder);
            this.SeedRoles(builder);
            this.SeedUsers(builder);
            this.SeedUsersRole(builder);
            this.SeedCourse(builder);
            this.SeedCourseStudent(builder);
        }
        private void SeedStudents(ModelBuilder builder)
        {
            Student student1 = new Student()
            {
                StudentId = new Guid("85eada75-f85d-400b-aef5-b06c9ba1fc7d"),
                FirstName = "Ahmet",
                LastName = "Boral",
                BirthDate = DateTime.Now.AddYears(-21),
                CourseId = "CSI101"
            };
            Student student2 = new Student()
            {
                StudentId = new Guid("5926176d-941c-4807-9d8b-cd7c350ca93d"),
                FirstName = "Mahmut",
                LastName = "Deniz",
                BirthDate = DateTime.Now.AddYears(-22),
                CourseId = "CSI102"
            };
            Student student3 = new Student()
            {
                StudentId = new Guid("09966f08-8e4a-4848-8809-bda93b6c9481"),
                FirstName = "Hakkı",
                LastName = "Deniz",
                BirthDate = DateTime.Now.AddYears(-22),
                CourseId = "MAT101"
            };
            builder.Entity<Student>().HasData(student1, student2, student3);
        }
        private void SeedRoles(ModelBuilder builder)
        {
            Role role1 = new Role() { RoleId = 1, RoleName = "Admin" };
            Role role2 = new Role() { RoleId = 2, RoleName = "User" };
            Role role3 = new Role() { RoleId = 3, RoleName = "Student" };
            builder.Entity<Role>().HasData(role1, role2);
        }
        private void SeedUsers(ModelBuilder builder)
        {
            User user1 = new User() { UserId = 1, UserName = "Erdogan_Canbay", Password = "123", FirstName = "Erdogan", LastName = "Canbay" };
            User user2 = new User() { UserId = 2, UserName = "Mahmut_Bulut", Password = "111", FirstName = "Mahmut", LastName = "Bulut" };
            User user3 = new User() { UserId = 3, UserName = "Emre_Kaya", Password = "1234", FirstName = "Emre", LastName = "Kaya" };
            builder.Entity<User>().HasData(user1, user2, user3);
        }
        private void SeedUsersRole(ModelBuilder builder)
        {
            UserRole userRole1 = new UserRole() { Id = 1, RoleId = 1, UserId = 1 };
            UserRole userRole2 = new UserRole() { Id = 2, RoleId = 2, UserId = 2 };
            UserRole userRole3 = new UserRole() { Id = 3, RoleId = 3, UserId = 3 };
            builder.Entity<UserRole>().HasData(userRole1, userRole2, userRole3);
        }
        private void SeedCourse(ModelBuilder builder)
        {
            Course course1 = new Course() { CourseId = "CSI101", CourseName = "Introduction to Computer Science" };
            Course course2 = new Course() { CourseId = "CSI102", CourseName = "Algorithms" };
            Course course3 = new Course() { CourseId = "MAT101", CourseName = "Calculus" };
            Course course4 = new Course() { CourseId = "PHY101", CourseName = "Physics" };
            builder.Entity<Course>().HasData(course1, course2, course3, course4);
        }
        private void SeedCourseStudent(ModelBuilder builder)
        {
            StudentCourse studentCourse0 = new StudentCourse() { Id = new Guid("e36500cb-462b-43de-a34a-43d11c8e86af"), StudentId = new Guid("85eada75-f85d-400b-aef5-b06c9ba1fc7d"), CourseId = "CSI101" };
            StudentCourse studentCourse1 = new StudentCourse() { Id = new Guid("b5f3a88d-980d-4ada-a7e3-c8ec10f83850"), StudentId = new Guid("85eada75-f85d-400b-aef5-b06c9ba1fc7d"), CourseId = "CSI102" };
            StudentCourse studentCourse2 = new StudentCourse() { Id = new Guid("bb1081b1-ba3c-413d-8103-82bcd55f96ed"), StudentId = new Guid("85eada75-f85d-400b-aef5-b06c9ba1fc7d"), CourseId = "MAT101" };
            StudentCourse studentCourse3 = new StudentCourse() { Id = new Guid("7674a62e-3b11-4b54-a465-9ae79cecd536"), StudentId = new Guid("5926176d-941c-4807-9d8b-cd7c350ca93d"), CourseId = "CSI102" };
            StudentCourse studentCourse4 = new StudentCourse() { Id = new Guid("2052b073-e42d-4a75-81ac-0a932182d320"), StudentId = new Guid("5926176d-941c-4807-9d8b-cd7c350ca93d"), CourseId = "MAT101" };
            StudentCourse studentCourse5 = new StudentCourse() { Id = new Guid("913bccde-2b1b-47e4-a607-335930d41d1c"), StudentId = new Guid("09966f08-8e4a-4848-8809-bda93b6c9481"), CourseId = "PHY101" };
            StudentCourse studentCourse6 = new StudentCourse() { Id = new Guid("d0827021-a9bb-4d1b-bdfa-c67748164456"), StudentId = new Guid("09966f08-8e4a-4848-8809-bda93b6c9481"), CourseId = "MAT101" };
            builder.Entity<StudentCourse>().HasData(studentCourse1, studentCourse2, studentCourse3, studentCourse4, studentCourse5, studentCourse6);
        }
    }
}
