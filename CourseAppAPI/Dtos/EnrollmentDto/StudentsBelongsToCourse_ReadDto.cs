using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Dtos
{
    public class StudentsBelongsToCourse_ReadDto
    {
        
        public int StudentCourseEnrollmentId { get; set; }

      
        public int StudentId { get; set; }

     
        public int CourseId { get; set; }
    }
}
