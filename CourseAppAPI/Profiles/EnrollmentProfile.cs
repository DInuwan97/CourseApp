using AutoMapper;
using CourseAppAPI.Models;
using CourseAppData.Dtos;
using CourseAppData.Dtos.EnrollmentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Profiles
{
    public class EnrollmentProfile : Profile
    {

        public EnrollmentProfile()
        {
            CreateMap<StudentCourseEnrollement, StudentsBelongsToCourse_ReadDto>();
            CreateMap<StudentsBelongsToCourse_CreateDto, StudentCourseEnrollement>();
        }
        //Source -> Target
        

            //CreateMap<CourseUpdateDto, Course>();
            //CreateMap<Course, CourseUpdateDto>();
    }
}
