using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Application.DTOs.CourseDTO
{
    public class CreateCourseDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int InstructorId { get; set; }
    }
}
