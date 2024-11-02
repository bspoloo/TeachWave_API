using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.ModuleDTO;

namespace TeachWaveAPI.Application.Interfaces
{
    public interface IModuleService
    {
        Task<IEnumerable<ModuleOutDTO>> getAllModulesAsync();
        Task<ModuleOutDTO?> getModulesByIdAsync(int id);
        Task<ModuleOutDTO?> createModuleAsync(CreateModuleDTO createDTO);
        Task<ModuleOutDTO?> updateModuleByIdAsync(int id, UpdateModuleDTO updateDto);
        Task<ModuleOutDTO?> deleteModuleByidAsync(int id);
    }
}
