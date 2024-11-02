using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Core.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<IEnumerable<Submission>> GetAllAsync();
        Task<Submission?> GetByIdAsync(int id);
        Task<Submission> AddAsync(Submission subimission);
        Task<Submission?> UpdateAsync(int id, Submission subimission);
        Task<Submission?> DeleteAsync(int id);
    }
}
