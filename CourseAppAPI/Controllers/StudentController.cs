using AutoMapper;
using CourseAppAPI.Data;
using CourseAppAPI.Models;
using CourseAppData.Dtos;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Controllers
{
    [Route("api/students")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepo _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepo repository, IMapper mapper) //Dependency Injection
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
        [HttpGet("{id}", Name = "GetStudentId")]
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


        //PUT api/students
        [HttpPut("{id}")]
        public ActionResult UpdateStudent(int id,StudentUpdateDto studentUpdateDto)
        {
            var studentModelFromRepo = _repository.GetStudentById(id);

            if(studentModelFromRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(studentUpdateDto,studentModelFromRepo);
                _repository.UpdateStudent(studentModelFromRepo);
                _repository.SaveChanges();
                return Ok();
            }
        }



        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialStudentUpdate(int id,JsonPatchDocument<StudentUpdateDto> patchDoc)
        {
            var studentModelForm = _repository.GetStudentById(id);
            if(studentModelForm == null)
            {
                return NotFound();
            }

            var studentToPatch = _mapper.Map<StudentUpdateDto>(studentModelForm);
            patchDoc.ApplyTo(studentToPatch, ModelState);

            if (!TryValidateModel(studentToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(studentToPatch, studentModelForm);
            _repository.SaveChanges();
            return Ok();
        }

    

    }
}
