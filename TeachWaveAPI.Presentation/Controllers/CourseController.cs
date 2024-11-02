using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Application.Services;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;
using TeachWaveAPI.Infraestructure.Persistence.Repositories;

namespace TeachWaveAPI.Presentation.Controllers
{
    [ApiController]
    [Route("teachwaveAPI/v1/courses")]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;

        public CourseController(AppDbContext context, IMapper _mapper, ICourseService personService)
        {
            _courseService = new CourseService(new CourseRepository(context), _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CourseOutDTO>>> getAllCourses()
        {
            try
            {
                var courses = await _courseService.getAllCoursesAsync();
                return Ok(new { success = true, message = "Courses retrived successfully", courses });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CourseOutDTO>> GetCourseById(int id)
        {
            try
            {
                var course = await _courseService.getCoursesByIdAsync(id);
                return Ok(new { success = true, message = "Course retrieved successfully", course });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult<CourseOutDTO>> CreateCourse([FromBody] CreateCourseDTO createDTO)
        {
            try
            {
                var createdCourse = await _courseService.createCoursenAsync(createDTO);
                return Ok(new { success = true, message = "Course created successfully.", data = createdCourse });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while creating the Course.", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<CourseOutDTO>> UpdateCourseById(int id, [FromBody] UpdateCourseDTO updateDTO)
        {
            try
            {
                var updatedCourse= await _courseService.updateCourseByIdAsync(id, updateDTO);
                return Ok(new { success = true, message = "Course updated successfully", updatedCourse });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        public async Task<ActionResult<CourseOutDTO>> deleteCourseById(int id)
        {
            try
            {
                var deletedCourse = await _courseService.deleteCourseByidAsync(id);
                return Ok(new { success = true, message = "Course deleted successfully", deletedCourse });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
