using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;

namespace TeachWaveAPI.Infraestructure.Persistence.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly AppDbContext _context;
        public ModuleRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<CourseModule> AddAsync(CourseModule module)
        {
            if (module == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            module.IsDeleted = false;

            await _context.Modules.AddAsync(module);
            await _context.SaveChangesAsync();
            return module;
        }

        public async Task<CourseModule?> DeleteAsync(int id)
        {
            CourseModule? module = await GetByIdAsync(id);

            if (module != null)
            {
                module.DeletedAt = DateTime.Now;
                module.IsDeleted = true;
                _context.Modules.Update(module);
                await _context.SaveChangesAsync();
                return module;
            }
            return null;
        }

        public async Task<IEnumerable<CourseModule>> GetAllAsync()
        {
            return await _context.Modules.AsNoTracking()
                .Where(u => u.IsDeleted != true)
                .ToListAsync();
        }

        public async Task<CourseModule?> GetByIdAsync(int id)
        {
            return await _context.Modules
                .Where(u => u.IsDeleted != true && u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<CourseModule?> UpdateAsync(int id, CourseModule module)
        {
            CourseModule? updateModule = await GetByIdAsync(id);

            if (updateModule == null)
            {
                throw new ArgumentNullException(nameof(module));
            }
            if (updateModule != null)
            {
                updateModule.UpdatedAt = DateTime.Now;
                _context.Entry(updateModule).CurrentValues.SetValues(module);
                _context.SaveChanges();
                return module;
            }
            return null;
        }
    }
}
