using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;

namespace TeachWaveAPI.Application.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserOutDTO>> getAllUsersAsync();
        Task<UserOutDTO?> getUsersByIdAsync(int id);
        Task<UserOutDTO?> createUsernAsync(CreateUserDTO createDTO);
        Task<UserOutDTO?> updateUserByIdAsync(int id, UpdateUserDTO updateDto);
        Task<UserOutDTO?> deleteUserByidAsync(int id);
    }
}
