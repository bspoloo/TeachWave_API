using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int AssignmentId { get; set; }
        public Assignment? Assignment { get; set; }

        [Required]
        public int StudentId { get; set; }
        public User? Student { get; set; } 
        public string? FilePath { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal? Grade { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "The Feedback must not exceed 500 characters.")]
        public string? Feedback { get; set; }
        public DateTime? GradedAt { get; set; }

        // Soft properties
        public bool IsDeleted { get; set; } = false;
        public DateTime? DeletedAt { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
