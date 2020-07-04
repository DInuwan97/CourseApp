using CourseAppAPI.Data;
using CourseAppAPI.Models;
using CourseAppData.Data;
using CourseAppData.Dtos.EnrollmentDto;
using CourseAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Data
{
    public class SqlStudentCourseEnrollementRepo : IStudentCourseEnrollement
    {
        private readonly CourseAppContext _context;

        public SqlStudentCourseEnrollementRepo(CourseAppContext context)
        {
            _context = context;
        }

        public void CreateEnrollement(StudentCourseEnrollement studentCourseEnrollement)
        {
            if (studentCourseEnrollement == null)
            {
                throw new ArgumentNullException(nameof(studentCourseEnrollement));
            }

            _context.StudentCourseEnrollments.Add(studentCourseEnrollement);
        }

        public IEnumerable<StudentCourseEnrollement> GetAllEnrollements()
        {
            return _context.StudentCourseEnrollments.ToList();
        }

        public IEnumerable<StudentCourseEnrollement> GetAllEnrollementsByCourseId()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<StudentCourseEnrollement> GetAllEnrollementsByStudentId()
        {
            throw new NotImplementedException();
        }

        public StudentCourseEnrollement GetStudentCourseEnrollmentsById(int id)
        {
            return _context.StudentCourseEnrollments.FirstOrDefault(p => p.StudentCourseEnrollmentId == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }

}
