using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.ModuleDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;

namespace TeachWaveAPI.Application.Services
{
    public class ModuleService : IModuleService
    {
        private readonly IModuleRepository _moduleRepository;
        private readonly IMapper _mapper;

        public ModuleService(IModuleRepository moduleRepository, IMapper mapper)
        {
            _moduleRepository = moduleRepository;
            _mapper = mapper;
        }

        public async Task<ModuleOutDTO?> createModuleAsync(CreateModuleDTO createDTO)
        {
            var module = _mapper.Map<CourseModule>(createDTO);
            var result = await _moduleRepository.AddAsync(module);
            return _mapper.Map<ModuleOutDTO>(result);
        }

        public async Task<ModuleOutDTO?> deleteModuleByidAsync(int id)
        {
            var result = await _moduleRepository.DeleteAsync(id);
            return _mapper.Map<ModuleOutDTO>(result);
        }

        public async Task<IEnumerable<ModuleOutDTO>> getAllModulesAsync()
        {
            var results = await _moduleRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ModuleOutDTO>>(results);
        }

        public async Task<ModuleOutDTO?> getModulesByIdAsync(int id)
        {
            var module = await _moduleRepository.GetByIdAsync(id);
            return _mapper.Map<ModuleOutDTO>(module);
        }

        public async Task<ModuleOutDTO?> updateModuleByIdAsync(int id, UpdateModuleDTO updateDto)
        {
            var existingModule = await _moduleRepository.GetByIdAsync(id);
            if (existingModule == null)
            {
                return null;
            }
            _mapper.Map(updateDto, existingModule);
            var updated = await _moduleRepository.UpdateAsync(id, existingModule);
            return _mapper.Map<ModuleOutDTO>(updated);
        }
    }
}
