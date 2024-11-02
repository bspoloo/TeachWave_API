using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Core.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task<Assignment?> GetByIdAsync(int id);
        Task<Assignment> AddAsync(Assignment assignment);
        Task<Assignment?> UpdateAsync(int id, Assignment assignment);
        Task<Assignment?> DeleteAsync(int id);
    }
}
