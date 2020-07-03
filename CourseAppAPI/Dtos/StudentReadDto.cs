using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Dtos
{
    public class StudentReadDto
    {
        public int StudentId { get; set; }
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Mobile { get; set; }
    }
}
