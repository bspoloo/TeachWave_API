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
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _context;
        public CourseRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Course> AddAsync(Course course)
        {
            if (course == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            course.IsDeleted = false;

            await _context.Courses.AddAsync(course);
            await _context.SaveChangesAsync();
            return course;
        }

        public async Task<Course?> DeleteAsync(int id)
        {
            Course? course = await GetByIdAsync(id);

            if (course != null)
            {
                course.DeletedAt = DateTime.Now;
                course.IsDeleted = true;
                _context.Courses.Update(course);
                await _context.SaveChangesAsync();
                return course;
            }
            return null;
        }

        public async Task<IEnumerable<Course>> GetAllAsync()
        {
            return await _context.Courses.AsNoTracking()
                .Where(u => u.IsDeleted != true)
                .ToListAsync();
        }

        public async Task<Course?> GetByIdAsync(int id)
        {
            return await _context.Courses
                .Where(u => u.IsDeleted != true && u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<Course?> UpdateAsync(int id, Course course)
        {
            Course? updateCourse = await GetByIdAsync(id);

            if (updateCourse == null)
            {
                throw new ArgumentNullException(nameof(course));
            }
            if (updateCourse != null)
            {
                updateCourse.UpdatedAt = DateTime.Now;
                _context.Entry(updateCourse).CurrentValues.SetValues(course);
                _context.SaveChanges();
                return course;
            }
            return null;
        }
    }
}
