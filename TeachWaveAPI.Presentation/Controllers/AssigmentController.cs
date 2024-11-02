using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachWaveAPI.Application.DTOs.AssignmentDTO;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Application.Services;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;
using TeachWaveAPI.Infraestructure.Persistence.Repositories;

namespace TeachWaveAPI.Presentation.Controllers
{
    [ApiController]
    [Route("teachwaveAPI/v1/assignments")]
    public class AssigmentController : ControllerBase
    {
        private readonly IAssignmentService _assignmentService;

        public AssigmentController(AppDbContext context, IMapper _mapper, IAssignmentService assignmentService)
        {
            _assignmentService = new AssignmentService(new AssigmentRepository(context), _mapper);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentOutDTO>>> getAllAssignments()
        {
            try
            {
                var assignments = await _assignmentService.getAllAssignmentsAsync();
                return Ok(new { success = true, message = "Assignments retrived successfully", assignments });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentOutDTO>> GetAssignmentById(int id)
        {
            try
            {
                var assignment = await _assignmentService.getAssignmentByIdAsync(id);
                return Ok(new { success = true, message = "Assignment retrieved successfully", assignment });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<AssignmentOutDTO>> CreateAssignment([FromBody] CreateAssignmentDTO createDTO)
        {
            try
            {
                var createdCourse = await _assignmentService.createAssignmentAsync(createDTO);
                return Ok(new { success = true, message = "Assignment created successfully.", data = createdCourse });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while creating the Assignment.", detail = ex.Message });
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<AssignmentOutDTO>> UpdateAssignmentById(int id, [FromBody] UpdateAssignmentDTO updateDTO)
        {
            try
            {
                var updatedCourse = await _assignmentService.updateAssignmentByIdAsync(id, updateDTO);
                return Ok(new { success = true, message = "Assignment updated successfully", updatedCourse });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssignmentOutDTO>> deleteAssignmentById(int id)
        {
            try
            {
                var deletedCourse = await _assignmentService.deleteAssignmentByidAsync(id);
                return Ok(new { success = true, message = "Assignment deleted successfully", deletedCourse });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
