using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class Submission
    {
        public int Id { get; set; }
        public int AssignmentId { get; set; }
        public Assignment Assignment { get; set; } 
        public int StudentId { get; set; }
        public User Student { get; set; } 
        public string FilePath { get; set; }
        public DateTime SubmissionDate { get; set; }
        public decimal? Grade { get; set; }
        public string Feedback { get; set; }
        public DateTime? GradedAt { get; set; }
    }
}
