using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Application.DTOs.SubmissionDTO
{
    public class CreateSubmissionDTO
    {
        public int AssignmentId { get; set; }
        public int StudentId { get; set; }
        public string? FilePath { get; set; }
        public decimal? Grade { get; set; }
        public string? Feedback { get; set; }
        public DateTime? GradedAt { get; set; }
    }
}
