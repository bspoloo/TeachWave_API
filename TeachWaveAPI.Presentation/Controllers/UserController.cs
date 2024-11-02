using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Application.Services;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;
using TeachWaveAPI.Infraestructure.Persistence.Repositories;

namespace TeachWaveAPI.Presentation.Controllers
{
    [ApiController]
    [Route("teachwaveAPI/v1/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(AppDbContext context, IMapper _mapper, IPersonService personService)
        {
            _userService = new UserService(new UserRepository(context), _mapper);
        }
        [Authorize]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserOutDTO>>> getAllUsers()
        {
            try
            {
                var users = await _userService.getAllUsersAsync();
                return Ok(new { success = true, message = "Users retrived successfully", users });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
        }
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<UserOutDTO>> GetUserById(int id)
        {
            try
            {
                var user = await _userService.getUsersByIdAsync(id);
                return Ok(new { success = true, message = "User retrieved successfully", user });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [Authorize]
        [HttpPost]
        public async Task<ActionResult<UserOutDTO>> CreateUser([FromBody] CreateUserDTO createDTO)
        {
            try
            {
                var createdUser = await _userService.createUsernAsync(createDTO);
                return Ok(new { success = true, message = "User created successfully.", data = createdUser });
            }
            catch (DbUpdateException ex)
            {
                return BadRequest(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { success = false, message = "An error occurred while creating the User.", detail = ex.Message });
            }
        }
        [Authorize]
        [HttpPut("{id}")]
        public async Task<ActionResult<UserOutDTO>> UpdateUserById(int id, [FromBody] UpdateUserDTO updateDTO)
        {
            try
            {
                var updatedPerson = await _userService.updateUserByIdAsync(id, updateDTO);
                return Ok(new { success = true, message = "User updated successfully", updatedPerson });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult<UserOutDTO>> deleteUserById(int id)
        {
            try
            {
                var deletedUser = await _userService.deleteUserByidAsync(id);
                return Ok(new { success = true, message = "User deleted successfully", deletedUser });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { success = false, message = ex.Message });
            }
        }
    }
}
