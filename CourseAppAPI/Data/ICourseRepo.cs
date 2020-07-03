using CourseAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Data
{
    public interface ICourseRepo
    {
        bool SaveChanges();

        IEnumerable<Course> GetAllCourses();
        Course GetCourseById(int CourseId);
        void CreateCourse(Course course);
        void UpdateCourse(Course course);
    }
}
