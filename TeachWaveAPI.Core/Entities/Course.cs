using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "The title must not exceed 50 characters")]
        public string? Title { get; set; } = "New Course";
        public string? Description { get; set; }

        [Required]
        public int? InstructorId { get; set; }
        public User? Instructor { get; set; } 
        public ICollection<CourseModule>? Modules { get; set; }
        public ICollection<Enrollment>? Enrollments { get; set; }

        // Soft properties
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
