using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using CourseAppAPI.Models;
using CourseAppData.Data;
using CourseAppData.Dtos;
using CourseAppData.Dtos.EnrollmentDto;
using CourseAppData.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CourseAppAPI.Data;

namespace CourseAppData.Controllers
{

    [Route("api/enroll")]
    [ApiController]
    public class StudentCourseEnrollmentController : ControllerBase
    {
        private readonly IStudentCourseEnrollement _repository;
        private readonly IMapper _mapper;

        public StudentCourseEnrollmentController(IStudentCourseEnrollement repository, IMapper mapper)
        {
            _repository = repository; //Dependecy Injection
            _mapper = mapper;
        }



        //GET api/commands  
        [HttpGet]
        public ActionResult<IEnumerable<StudentsBelongsToCourse_ReadDto>> GetAllEnrollments()
        {
            var enrollItems = _repository.GetAllEnrollements();
            return Ok(_mapper.Map<IEnumerable<StudentsBelongsToCourse_ReadDto>>(enrollItems));
        }



        //GET api/commands/1 
        [HttpGet("{id}", Name = "GetEnrollemetById")]
        public ActionResult<StudentsBelongsToCourse_ReadDto> GetEnrollemetById(int id)
        {
            var enrollItem = _repository.GetStudentCourseEnrollmentsById(id);

            if (enrollItem != null)
                return Ok(_mapper.Map<StudentsBelongsToCourse_ReadDto>(enrollItem));
            return NotFound();

        }





        //POST api/commands
        [HttpPost]
        public ActionResult<StudentsBelongsToCourse_ReadDto> CreateEnroll(StudentsBelongsToCourse_CreateDto studentsBelongsToCourse_CreateDto)
        {
            var enrollModel = _mapper.Map<StudentCourseEnrollement>(studentsBelongsToCourse_CreateDto);
            _repository.CreateEnrollement(enrollModel);
            _repository.SaveChanges();


            var enrollReadDto = _mapper.Map<StudentsBelongsToCourse_ReadDto>(enrollModel);

            return CreatedAtRoute(nameof(GetEnrollemetById), new { StudentCourseEnrollmentId = enrollReadDto.StudentCourseEnrollmentId }, enrollReadDto);
        }

    

    }
}
