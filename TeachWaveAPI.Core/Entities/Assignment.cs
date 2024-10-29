using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class Assignment
    {
        public int Id { get; set; }
        public int ModuleId { get; set; }
        public CourseModule Module { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public ICollection<Submission> Submissions { get; set; }
    }
}
