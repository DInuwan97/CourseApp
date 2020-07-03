using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseAppAPI.Models;
using CourseAppData.Dtos;

namespace CourseAppData.Profiles
{
    public class StudentProfiles:Profile
    {
        public StudentProfiles()
        {
            //Source -> Target
            CreateMap<Student, StudentReadDto>();
            CreateMap<StudentCreateDto, Student>();
            CreateMap<StudentUpdateDto, Student>();
            CreateMap<Student, StudentUpdateDto>();
        }
       
    }
}
