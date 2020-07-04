using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseAppAPI.Models;
using CourseAppData.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAppAPI.Data
{
 
    public class CourseAppContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourseEnrollement> StudentCourseEnrollments { get; set; }


        public CourseAppContext(DbContextOptions<CourseAppContext> opt) : base(opt)
        {

        }
    }
}
