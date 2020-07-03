using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CourseAppAPI.Data;
using CourseAppAPI.Models;
using CourseAppData.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CourseAppWebAPI.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }




        //GET api/students
        [HttpGet]
        public ActionResult<IEnumerable<StudentReadDto>> GetAllStudents()
        {
            var studentItems = _repository.GetAllStudents();
            return Ok(_mapper.Map<IEnumerable<StudentReadDto>>(studentItems));
        }






        //GET api/students/{id}
        [HttpGet("{id}", Name ="GetStudentId")]
        public ActionResult<StudentReadDto> GetStudentById(int id)
        {
            var studentsItem = _repository.GetStudentById(id);
            if (studentsItem != null)
                return Ok(_mapper.Map<StudentReadDto>(studentsItem));
            return NotFound();
        }





        //POST api/students
        [HttpPost]
        public ActionResult<StudentReadDto> CreateStudent(StudentCreateDto studentCreateDto)
        {
            var studentModel = _mapper.Map<Student>(studentCreateDto);
            _repository.CreateStudent(studentModel);
            _repository.SaveChanges();

            var studentReadDto = _mapper.Map<StudentReadDto>(studentModel);

            return CreatedAtRoute(nameof(GetStudentById), new { StudentID = studentReadDto.StudentId }, studentReadDto);

        }

    }
}
