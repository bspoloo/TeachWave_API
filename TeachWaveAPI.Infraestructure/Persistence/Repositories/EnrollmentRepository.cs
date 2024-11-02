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
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly AppDbContext _context;
        public EnrollmentRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Enrollment> AddAsync(Enrollment enrollment)
        {
            if (enrollment == null)
            {
                throw new ArgumentNullException(nameof(enrollment));
            }
            enrollment.IsDeleted = false;

            await _context.Enrollments.AddAsync(enrollment);
            await _context.SaveChangesAsync();
            return enrollment;
        }

        public async Task<Enrollment?> DeleteAsync(int id)
        {
            Enrollment? enrollment = await GetByIdAsync(id);

            if (enrollment != null)
            {
                enrollment.DeletedAt = DateTime.Now;
                enrollment.IsDeleted = true;
                _context.Enrollments.Update(enrollment);
                await _context.SaveChangesAsync();
                return enrollment;
            }
            return null;
        }

        public async Task<IEnumerable<Enrollment>> GetAllAsync()
        {
            return await _context.Enrollments.AsNoTracking()
                .Where(u => u.IsDeleted != true)
                .ToListAsync();
        }

        public async Task<Enrollment?> GetByIdAsync(int id)
        {
            return await _context.Enrollments
                .Where(u => u.IsDeleted != true && u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Enrollment?> UpdateAsync(int id, Enrollment enrollment)
        {
            Enrollment? updateEnrollement = await GetByIdAsync(id);

            if (updateEnrollement == null)
            {
                throw new ArgumentNullException(nameof(enrollment));
            }
            if (updateEnrollement != null)
            {
                updateEnrollement.UpdatedAt = DateTime.Now;
                _context.Entry(updateEnrollement).CurrentValues.SetValues(enrollment);
                _context.SaveChanges();
                return enrollment;
            }
            return null;
        }
    }
}
