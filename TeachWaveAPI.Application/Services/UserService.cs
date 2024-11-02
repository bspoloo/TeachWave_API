using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;

namespace TeachWaveAPI.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserOutDTO?> createUsernAsync(CreateUserDTO createDTO)
        {
            var user = _mapper.Map<User>(createDTO);
            var result = await _userRepository.AddAsync(user);
            return _mapper.Map<UserOutDTO>(result);
        }

        public async Task<UserOutDTO?> deleteUserByidAsync(int id)
        {
            var result = await _userRepository.DeleteAsync(id);
            return _mapper.Map<UserOutDTO>(result);
        }

        public async Task<IEnumerable<UserOutDTO>> getAllUsersAsync()
        {
            var results = await _userRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<UserOutDTO>>(results);
        }

        public async Task<UserOutDTO?> getUsersByIdAsync(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            return _mapper.Map<UserOutDTO>(user);
        }

        public async Task<UserOutDTO?> updateUserByIdAsync(int id, UpdateUserDTO updateDto)
        {
            var existingUser = await _userRepository.GetByIdAsync(id);
            if (existingUser == null)
            {
                return null;
            }
            _mapper.Map(updateDto, existingUser);
            var updated = await _userRepository.UpdateAsync(id, existingUser);
            return _mapper.Map<UserOutDTO>(updated);
        }
    }
}
