using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Dtos.CourseDto
{
    public class CourseReadDto
    {
        public int CourseId { get; set; }
        public String CourseName { get; set; }
        public String ModuleCode { get; set; }
        public String EntollmentKey { get; set; }
    }
}
