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
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;
        public PersonRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task<Person> AddAsync(Person person)
        {
            if (person == null)
            {
                throw new ArgumentNullException(nameof(person));
            }
            await _context.Persons.AddAsync(person);
            await _context.SaveChangesAsync();
            return person;
        }

        public async Task<Person?> DeleteAsync(int id)
        {
            Person? person = await GetByIdAsync(id);

            if (person != null)
            {
                _context.Persons.Remove(person);
                await _context.SaveChangesAsync();
                return person;
            }
            return null;
        }

        public async Task<IEnumerable<Person>> GetAllAsync()
        {
            return await _context.Persons.AsNoTracking().ToListAsync();
        }

        public async Task<Person?> GetByIdAsync(int id)
        {
            return await _context.Persons.FindAsync(id);
        }

        public async Task<Person?> UpdateAsync(int id, Person person)
        {
            Person? upatePerson = await GetByIdAsync(id);

            if (upatePerson == null)
            {
                throw new ArgumentNullException(nameof(person));
            }

            if (upatePerson != null)
            {
                _context.Entry(upatePerson).CurrentValues.SetValues(person);
                _context.SaveChanges();
                return person;
            }
            return null;
        }
    }
}
