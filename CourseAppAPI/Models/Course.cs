using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [MaxLength(100)]
        public String CourseName { get; set; }

        [Required]
        [MaxLength(10)]
        public String ModuleCode { get; set; }

        [Required]
        [MaxLength(50)]
        public String EntollmentKey { get; set; }

    }
}
