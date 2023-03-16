using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusysDemo.Entities
{
    public class Course
    {
        public Course()
        {
            Students = new List<Student>();
        }
        public string CourseId { get; set; }
        public string CourseName { get; set; }
        public Guid StudentId { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}
