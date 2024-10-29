using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int InstructorId { get; set; }
        public User Instructor { get; set; } 
        public ICollection<CourseModule> Modules { get; set; }
        public ICollection<Enrollment> Enrollments { get; set; }
    }
}
