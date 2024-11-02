using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.ModuleDTO;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Application.Services;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;
using TeachWaveAPI.Infraestructure.Persistence.Repositories;

namespace TeachWaveAPI.Presentation.Controllers
{
    [ApiController]
    [Route("teachwaveAPI/v1/modules")]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleService _moduleService;

        public ModuleController(AppDbContext context, IMapper _mapper, IModuleService moduleService)
        {
            _moduleService = new ModuleService(new ModuleRepository(context), _mapper);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModuleOutDTO>>> getAllModules()
        {
            try
            {
                var modules = await _moduleService.getAllModulesAsync();
                return Ok(new { success = true, message = "Modules retrived successfully", modules });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ModuleOutDTO>> GetModuleById(int id)
        {
            try
            {
                var module = await _moduleService.getModulesByIdAsync(id);
                return Ok(new { success = true, message = "Module retrieved successfully", module });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult<ModuleOutDTO>> CreateModule([FromBody] CreateModuleDTO createDTO)
        {
            try
            {
                var createdModule = await _moduleService.createModuleAsync(createDTO);
                return Ok(new { success = true, message = "Module created successfully.", data = createdModule });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while creating the Module.", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ModuleOutDTO>> UpdateModuleById(int id, [FromBody] UpdateModuleDTO updateDTO)
        {
            try
            {
                var updatedModule = await _moduleService.updateModuleByIdAsync(id, updateDTO);
                return Ok(new { success = true, message = "Module updated successfully", updatedModule });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        public async Task<ActionResult<ModuleOutDTO>> deleteModuleById(int id)
        {
            try
            {
                var deletedCourse = await _moduleService.deleteModuleByidAsync(id);
                return Ok(new { success = true, message = "Module deleted successfully", deletedCourse });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
