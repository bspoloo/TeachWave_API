using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Core.Interfaces
{
    public interface IModuleRepository
    {
        Task<IEnumerable<CourseModule>> GetAllAsync();
        Task<CourseModule?> GetByIdAsync(int id);
        Task<CourseModule> AddAsync(CourseModule module);
        Task<CourseModule?> UpdateAsync(int id, CourseModule module);
        Task<CourseModule?> DeleteAsync(int id);
    }
}
