using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.DTOs.SubmissionDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Application.Services;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;
using TeachWaveAPI.Infraestructure.Persistence.Repositories;

namespace TeachWaveAPI.Presentation.Controllers
{
    [ApiController]
    [Route("teachwaveAPI/v1/submissions")]
    public class SubmissionController : ControllerBase
    {
        private readonly ISubmissionService _submissionService;

        public SubmissionController(AppDbContext context, IMapper _mapper, ISubmissionService submissionService)
        {
            _submissionService = new SubmissionService(new SubmissionRepositoy(context), _mapper);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SubmissionOutDTO>>> getAllSubmissions()
        {
            try
            {
                var submissions = await _submissionService.getAllSubmissionsAsync();
                return Ok(new { success = true, message = "Submissions retrived successfully", submissions });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SubmissionOutDTO>> GetSubmissionById(int id)
        {
            try
            {
                var user = await _submissionService.getSubmissionByIdAsync(id);
                return Ok(new { success = true, message = "Submission retrieved successfully", user });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult<SubmissionOutDTO>> CreateSubmission([FromBody] CreateSubmissionDTO createDTO)
        {
            try
            {
                var createdSubmission = await _submissionService.createSubmissionAsync(createDTO);
                return Ok(new { success = true, message = "Submission created successfully.", data = createdSubmission });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while creating the Submission.", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<SubmissionOutDTO>> UpdateSubmissionById(int id, [FromBody] UpdateSubmissionDTO updateDTO)
        {
            try
            {
                var updatedSubmission = await _submissionService.updateSubmissionByIdAsync(id, updateDTO);
                return Ok(new { success = true, message = "Submission updated successfully", updatedSubmission });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        public async Task<ActionResult<SubmissionOutDTO>> deleteSubmissionById(int id)
        {
            try
            {
                var deletedSubmission = await _submissionService.deleteSubmissionByidAsync(id);
                return Ok(new { success = true, message = "Submission deleted successfully", deletedSubmission });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
