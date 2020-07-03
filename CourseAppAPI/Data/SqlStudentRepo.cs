using CourseAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppAPI.Data
{
    public class SqlStudentRepo : IStudentRepo
    {

        private readonly CourseAppContext _context;

        public SqlStudentRepo(CourseAppContext context)
        {
            _context = context;
        }

        public void CreateStudent(Student student)
        {

            if(student == null)
            {
                throw new ArgumentNullException(nameof(student));
            }

            _context.Students.Add(student);
        }


        public IEnumerable<Student> GetAllStudents()
        {
            return _context.Students.ToList();
        }

        public Student GetStudentById(int StudentId)
        {
            return _context.Students.FirstOrDefault(p => p.StudentId == StudentId);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateStudent(Student student)
        {
            //Nothing
        }
    }
}
