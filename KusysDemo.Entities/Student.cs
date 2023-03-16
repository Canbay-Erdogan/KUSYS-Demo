using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusysDemo.Entities
{
    public class Student
    {
        public Student()
        {
            Courses=new List<Course>();
        }
        public Guid StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string CourseId { get; set; }
        public List<Course> Courses { get; set; }
    }
}
