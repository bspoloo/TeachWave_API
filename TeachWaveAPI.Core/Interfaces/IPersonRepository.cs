using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Core.Interfaces
{
    public interface IPersonRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User?> GetByIdAsync(int id);
        Task<User> AddAsync(User person);
        Task<User?> UpdateAsync(int id, User person);
        Task<User?> DeleteAsync(int id);
    }
}
