using CourseAppAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppAPI.Data
{
    public interface IStudentRepo
    {

        bool SaveChanges();

        IEnumerable<Student> GetAllStudents();
        Student GetStudentById(int StudentId);
        void CreateStudent(Student student);
        void UpdateStudent(Student student);


    }
}
