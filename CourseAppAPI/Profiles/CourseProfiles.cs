using AutoMapper;
using CourseAppData.Dtos.CourseDto;
using CourseAppData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Profiles
{
    public class CourseProfiles:Profile
    {
        public CourseProfiles()
        {
            //Source -> Target
            CreateMap<Course, CourseReadDto>();
            CreateMap<CourseCreateDto, Course>();
            CreateMap<CourseUpdateDto, Course>();
            CreateMap<Course, CourseUpdateDto>();
        }
    }
}
