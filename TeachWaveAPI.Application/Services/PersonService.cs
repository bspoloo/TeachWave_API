using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;

namespace TeachWaveAPI.Application.Services
{
    public class PersonService : IPersonService
    {
        private readonly IPersonRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonService(IPersonRepository personRepository, IMapper mapper)
        {
            _personRepository = personRepository;
            _mapper = mapper;
        }

        public async Task<PersonOutDTO?> createPersonAsync(CreatePersonDTO personDTO)
        {
            var person = _mapper.Map<Person>(personDTO);
            var result = await _personRepository.AddAsync(person);
            return _mapper.Map<PersonOutDTO>(result);
        }

        public async Task<PersonOutDTO?> deletePersonByidAsync(int id_person)
        {
            var result = await _personRepository.DeleteAsync(id_person);
            return _mapper.Map<PersonOutDTO>(result);
        }

        public async Task<IEnumerable<PersonOutDTO>> getAllPersonsAsync()
        {
            var results = await _personRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PersonOutDTO>>(results);
        }

        public async Task<PersonOutDTO?> getPersonsByIdAsync(int id_person)
        {
            var person = await _personRepository.GetByIdAsync(id_person);
            return _mapper.Map<PersonOutDTO>(person);
        }

        public async Task<PersonOutDTO?> updatePersonByIdAsync(int id_person, UpdatePersonDTO updateDto)
        {
            var existingPerson = await _personRepository.GetByIdAsync(id_person);
            if (existingPerson == null)
            {
                return null;
            }
            _mapper.Map(updateDto, existingPerson);
            var updated = await _personRepository.UpdateAsync(id_person, existingPerson);
            return _mapper.Map<PersonOutDTO>(updated);
        }
    }
}
