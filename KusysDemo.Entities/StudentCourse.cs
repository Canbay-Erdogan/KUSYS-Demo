using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KusysDemo.Entities
{
    public class StudentCourse
    {
        public Guid Id { get; set; }
        public Guid StudentId { get; set; }
        public Student? Students { get; set; }
        public string? CourseId { get; set; }
        public Course? Course { get; set; }
    }
}
