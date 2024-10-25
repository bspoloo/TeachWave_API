using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Application.Services;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;
using TeachWaveAPI.Infraestructure.Persistence.Repositories;

namespace TeachWaveAPI.Presentation.Controllers
{
    [ApiController]
    [Route("teachwaveAPI/v1/persons")]

    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(AppDbContext context,IMapper _mapper, IPersonService personService)
        {
            _personService = new PersonService(new PersonRepository(context), _mapper);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonOutDTO>>> getAllPersons()
        {
            try
            {
                var persons = await _personService.getAllPersonsAsync();
                return Ok(new { success = true, message = "Persons retrived successfully", persons });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonOutDTO>> GetPersonByID(int id)
        {
            try
            {
                var person = await _personService.getPersonsByIdAsync(id);
                return Ok(new { success = true, message = "User retrieved successfully", person });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpPost]
        public async Task<ActionResult<PersonOutDTO>> CreatePerson([FromBody] CreatePersonDTO createDTO)
        {
            try
            {
                var createdPerson = await _personService.createPersonAsync(createDTO);
                return Ok(new { success = true, message = "Person created successfully.", data = createdPerson });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while creating the collection.", detail = ex.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PersonOutDTO>> UpdatePerson(int id, [FromBody] UpdatePersonDTO updateDTO)
        {
            try
            {
                var updatedPerson = await _personService.updatePersonByIdAsync(id, updateDTO);
                return Ok(new { success = true, message = "Person updated successfully", updatedPerson });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [HttpDelete]
        public async Task<ActionResult<PersonOutDTO>> deletePersonById(int id)
        {
            try
            {
                var deletedPerson = await _personService.deletePersonByidAsync(id);
                return Ok(new { success = true, message = "Person deleted successfully", deletedPerson });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
