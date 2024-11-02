using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Application.DTOs.ModuleDTO
{
    public class UpdateModuleDTO
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int CourseId { get; set; }
    }
}
