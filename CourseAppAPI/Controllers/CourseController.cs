using AutoMapper;
using CourseAppData.Data;
using CourseAppData.Dtos.CourseDto;
using CourseAppData.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CourseAppData.Controllers
{
    [Route("api/courses")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseRepo _repository;
        private readonly IMapper _mapper;

        public CourseController(ICourseRepo repository, IMapper mapper) //Dependency Injection
        {
            _repository = repository;
            _mapper = mapper;
        }




        //GET api/courses
        [HttpGet]
        public ActionResult<IEnumerable<CourseReadDto>> GetAllCourses()
        {
            var courseItems = _repository.GetAllCourses();
            return Ok(_mapper.Map<IEnumerable<CourseReadDto>>(courseItems));
        }



        //GET api/courses/{id}
        [HttpGet("{id}", Name = "GetCourseId")]
        public ActionResult<CourseReadDto> GetCourseById(int id)
        {
            var courseItem = _repository.GetCourseById(id);
            if (courseItem != null)
                return Ok(_mapper.Map<CourseReadDto>(courseItem));
            return NotFound();
        }





        //POST api/courses
        [HttpPost]
        public ActionResult<CourseReadDto> CreateCourse(CourseCreateDto courseCreateDto)
        {
            var courseModel = _mapper.Map<Course>(courseCreateDto);
            _repository.CreateCourse(courseModel);
            _repository.SaveChanges();

            var courseReadDto = _mapper.Map<CourseReadDto>(courseModel);

            return CreatedAtRoute(nameof(GetCourseById), new { CourseID = courseReadDto.CourseId }, courseReadDto);

        }





        //PUT api/students
        [HttpPut("{id}")]
        public ActionResult UpdateCourse(int id, CourseUpdateDto studentUpdateDto)
        {
            var courseModelFormRepo = _repository.GetCourseById(id);

            if (courseModelFormRepo == null)
            {
                return NotFound();
            }
            else
            {
                _mapper.Map(studentUpdateDto, courseModelFormRepo);
                _repository.UpdateCourse(courseModelFormRepo);
                _repository.SaveChanges();
                return Ok();
            }
        }



        //PATCH api/commands/{id}
        [HttpPatch("{id}")]
        public ActionResult PartialCourseUpdate(int id, JsonPatchDocument<CourseUpdateDto> patchDoc)
        {
            var courseModelFormRepo = _repository.GetCourseById(id);
            if (courseModelFormRepo == null)
            {
                return NotFound();
            }

            var courseToPatch = _mapper.Map<CourseUpdateDto>(courseModelFormRepo);
            patchDoc.ApplyTo(courseToPatch, ModelState);

            if (!TryValidateModel(courseToPatch))
            {
                return ValidationProblem(ModelState);
            }
            _mapper.Map(courseToPatch, courseModelFormRepo);
            _repository.SaveChanges();
            return Ok();
        }


    }
}
