using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class CourseModule
    {
        public int Id { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
    }
}
