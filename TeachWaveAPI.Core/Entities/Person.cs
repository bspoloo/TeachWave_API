using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeachWaveAPI.Core.Entities
{
    public class Person
    {
        [Key]
        public int id { get; set; }

        [Required]
        [StringLength(100)]
        public string? names { get; set; }

        [Required]
        [StringLength(50)]
        public string? first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string?  last_name{ get; set; }

        [Required]
        [StringLength(100)]
        public string? email { get; set; }

        [Required]
        [StringLength(20)]
        public string? phone { get; set; }

        [Required]
        [StringLength(100)]
        public string? address { get; set; }
    }
}
