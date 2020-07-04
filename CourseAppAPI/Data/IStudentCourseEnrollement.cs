using CourseAppAPI.Models;
using CourseAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppAPI.Data
{
    public interface IStudentCourseEnrollement
    {
        bool SaveChanges();


        void CreateEnrollement(StudentCourseEnrollement studentCourseEnrollement);
        IEnumerable<StudentCourseEnrollement> GetAllEnrollements();
        StudentCourseEnrollement GetStudentCourseEnrollmentsById(int id);


        IEnumerable<StudentCourseEnrollement> GetAllEnrollementsByStudentId();
        IEnumerable<StudentCourseEnrollement> GetAllEnrollementsByCourseId();
    }
}
