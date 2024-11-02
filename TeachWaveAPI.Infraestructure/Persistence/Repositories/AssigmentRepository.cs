using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;
using TeachWaveAPI.Infraestructure.Persistence.Contexts;

namespace TeachWaveAPI.Infraestructure.Persistence.Repositories
{
    public class AssigmentRepository : IAssignmentRepository
    {
        private readonly AppDbContext _context;
        public AssigmentRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Assignment> AddAsync(Assignment assignment)
        {
            if (assignment == null)
            {
                throw new ArgumentNullException(nameof(assignment));
            }
            assignment.IsDeleted = false;

            await _context.Assignments.AddAsync(assignment);
            await _context.SaveChangesAsync();
            return assignment;
        }

        public async Task<Assignment?> DeleteAsync(int id)
        {
            Assignment? assignment = await GetByIdAsync(id);

            if (assignment != null)
            {
                assignment.DeletedAt = DateTime.Now;
                assignment.IsDeleted = true;
                _context.Assignments.Update(assignment);
                await _context.SaveChangesAsync();
                return assignment;
            }
            return null;
        }

        public async Task<IEnumerable<Assignment>> GetAllAsync()
        {
            return await _context.Assignments.AsNoTracking()
                .Where(u => u.IsDeleted != true)
                .ToListAsync();
        }

        public async Task<Assignment?> GetByIdAsync(int id)
        {
            return await _context.Assignments
                .Where(u => u.IsDeleted != true && u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Assignment?> UpdateAsync(int id, Assignment assignment)
        {
            Assignment? updateAssignment = await GetByIdAsync(id);

            if (updateAssignment == null)
            {
                throw new ArgumentNullException(nameof(assignment));
            }
            if (updateAssignment != null)
            {
                updateAssignment.UpdatedAt = DateTime.Now;
                _context.Entry(updateAssignment).CurrentValues.SetValues(assignment);
                _context.SaveChanges();
                return assignment;
            }
            return null;
        }
    }
}
