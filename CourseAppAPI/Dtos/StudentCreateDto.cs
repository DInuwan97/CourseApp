using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Dtos
{
    public class StudentCreateDto
    {
        [Required]
        [MaxLength(50)]
        public String FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public String LastName { get; set; }

        [Required]
        [MaxLength(100)]
        public String Email { get; set; }

        [Required]
        [MaxLength(15)]
        public String Mobile { get; set; }
    }
}
