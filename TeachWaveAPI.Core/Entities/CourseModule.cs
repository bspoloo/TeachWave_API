using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class CourseModule
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int CourseId { get; set; }
        public Course? Course { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Title must not exceed 50 characters.")]
        public string? Title { get; set; }

        [MaxLength(50, ErrorMessage = "The Description must not exceed 500 characters.")]
        public string? Description { get; set; }
        public ICollection<Assignment>? Assignments { get; set; }

        // Soft properties
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
