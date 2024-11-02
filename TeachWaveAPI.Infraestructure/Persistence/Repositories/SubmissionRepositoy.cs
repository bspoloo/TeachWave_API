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
    public class SubmissionRepositoy : ISubmissionRepository
    {
        private readonly AppDbContext _context;
        public SubmissionRepositoy(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Submission> AddAsync(Submission subimission)
        {
            if (subimission == null)
            {
                throw new ArgumentNullException(nameof(subimission));
            }
            subimission.CreatedAt = DateTime.Now;
            subimission.UpdatedAt = DateTime.Now;
            subimission.IsDeleted = false;

            await _context.Submissions.AddAsync(subimission);
            await _context.SaveChangesAsync();
            return subimission;
        }

        public async Task<Submission?> DeleteAsync(int id)
        {
            Submission? submission = await GetByIdAsync(id);

            if (submission != null)
            {
                submission.DeletedAt = DateTime.Now;
                submission.IsDeleted = true;
                _context.Submissions.Update(submission);
                await _context.SaveChangesAsync();
                return submission;
            }
            return null;
        }

        public async Task<IEnumerable<Submission>> GetAllAsync()
        {
            return await _context.Submissions.AsNoTracking()
                .Where(u => u.IsDeleted != true)
                .ToListAsync();
        }

        public async Task<Submission?> GetByIdAsync(int id)
        {
            return await _context.Submissions
               .Where(u => u.IsDeleted != true && u.Id == id)
               .FirstOrDefaultAsync();
        }

        public async Task<Submission?> UpdateAsync(int id, Submission subimission)
        {
            Submission? updateSubmission = await GetByIdAsync(id);

            if (updateSubmission == null)
            {
                throw new ArgumentNullException(nameof(subimission));
            }
            if (updateSubmission != null)
            {
                updateSubmission.UpdatedAt = DateTime.Now;
                _context.Entry(updateSubmission).CurrentValues.SetValues(subimission);
                _context.SaveChanges();
                return subimission;
            }
            return null;
        }
    }
}
