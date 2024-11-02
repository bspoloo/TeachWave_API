using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class Assignment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int ModuleId { get; set; }
        public CourseModule? Module { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The Title must not exceed 50 characters.")]
        public string? Title { get; set; }
        [MaxLength(500, ErrorMessage = "The Description must not exceed 500 characters.")]
        public string? Description { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<Submission>? Submissions { get; set; }


        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;


    }
}
