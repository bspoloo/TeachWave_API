using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Application.DTOs.EnrollmentsDTO
{
    public class CreateEnrollmentDTO
    {
        public int CourseId { get; set; }
        public int StudentId { get; set; }
        public DateTime EnrollmentDate { get; set; }
    }
}
