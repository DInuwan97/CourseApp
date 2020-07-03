using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseAppAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CourseAppAPI.Data
{
 
    public class StudentContext : DbContext
    {
        public DbSet<Student> Students { get; set; }

        public StudentContext(DbContextOptions<StudentContext> opt) : base(opt)
        {

        }
    }
}
