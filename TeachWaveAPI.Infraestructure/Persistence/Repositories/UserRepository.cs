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
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<User> AddAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            user.CreatedAt = DateTime.Now; 
            user.UpdatedAt = DateTime.Now;
            user.IsDeleted = false;

            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User?> DeleteAsync(int id)
        {
            User? user = await GetByIdAsync(id);

            if (user != null)
            {
                user.DeletedAt = DateTime.Now;
                user.IsDeleted = true;
                _context.Users.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }
            return null;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.AsNoTracking()
                .Where(u => u.IsDeleted != true)
                .ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            return await _context.Users
                .Where(u => u.IsDeleted != true && u.Id == id)
                .FirstOrDefaultAsync();
        }

        public async Task<User?> UpdateAsync(int id, User user)
        {
            User? updateUser = await GetByIdAsync(id);

            if (updateUser == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            if (updateUser != null)
            {
                updateUser.UpdatedAt = DateTime.Now;
                _context.Entry(updateUser).CurrentValues.SetValues(user);
                _context.SaveChanges();
                return user;
            }
            return null;
        }
    }
}
