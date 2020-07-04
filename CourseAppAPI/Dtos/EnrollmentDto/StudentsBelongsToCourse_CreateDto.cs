using CourseAppData.Dtos.CourseDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Dtos.EnrollmentDto
{
    public class StudentsBelongsToCourse_CreateDto
    {
        //   public CourseReadDto courseDetails { get; set; }

        // public List<StudentReadDto> studentsList { get; set; }

        [Required]
        public int StudentId;

        [Required]
        public int CourseId;
    }
}
