using CourseAppAPI.Data;
using CourseAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Data
{
    public class SqlCourseRepo : ICourseRepo
    {
        private readonly CourseAppContext _context;

        public SqlCourseRepo(CourseAppContext context)
        {
            _context = context;
        }
        public void CreateCourse(Course course)
        {
           if(course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }

            _context.Courses.Add(course);
        }

        public IEnumerable<Course> GetAllCourses()
        {
            return _context.Courses.ToList();
        }

        public Course GetCourseById(int CourseId)
        {
            return _context.Courses.FirstOrDefault(p => p.CourseId == CourseId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCourse(Course course)
        {
            //Nothing
        }
    }
}
