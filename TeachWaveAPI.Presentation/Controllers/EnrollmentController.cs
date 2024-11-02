using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.EnrollmentsDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Application.Services;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;
using TeachWaveAPI.Infraestructure.Persistence.Repositories;

namespace TeachWaveAPI.Presentation.Controllers
{
    [ApiController]
    [Route("teachwaveAPI/v1/enrollments")]
    public class EnrollmentController : ControllerBase
    {
        private readonly IEnrollmentService _enrollmentService;

        public EnrollmentController(AppDbContext context, IMapper _mapper, IEnrollmentService enrollmentService)
        {
            _enrollmentService = new EnrollmentService(new EnrollmentRepository(context), _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnrollmentOutDTO>>> getAllEnrollments()
        {
            try
            {
                var enrollments = await _enrollmentService.getAllEnrollmentsAsync();
                return Ok(new { success = true, message = "Enrollments retrived successfully", enrollments });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<EnrollmentOutDTO>> GetEnrollmentById(int id)
        {
            try
            {
                var enrollment = await _enrollmentService.getEnrollmentByIdAsync(id);
                return Ok(new { success = true, message = "Enrollment retrieved successfully", enrollment });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult<EnrollmentOutDTO>> CreateEnrollment([FromBody] CreateEnrollmentDTO createDTO)
        {
            try
            {
                var createdCourse = await _enrollmentService.createEnrollmentAsync(createDTO);
                return Ok(new { success = true, message = "Enrollment created successfully.", data = createdCourse });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while creating the Enrollment.", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<EnrollmentOutDTO>> UpdateEnrollmentById(int id, [FromBody] UpdateEnrollmentDTO updateDTO)
        {
            try
            {
                var updatedEnrollment = await _enrollmentService.updateEnrollmentByIdAsync(id, updateDTO);
                return Ok(new { success = true, message = "Enrollment updated successfully", updatedEnrollment });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        public async Task<ActionResult<EnrollmentOutDTO>> deleteEnrollmentById(int id)
        {
            try
            {
                var deletedEnrollment = await _enrollmentService.deleteEnrollmentByidAsync(id);
                return Ok(new { success = true, message = "Enrollment deleted successfully", deletedEnrollment });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
