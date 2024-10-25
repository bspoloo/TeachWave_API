using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Application.Interfaces
{
    public interface IPersonService
    {
        Task<IEnumerable<PersonOutDTO>> getAllPersonsAsync();
        Task<PersonOutDTO?> getPersonsByIdAsync(int id_person);
        Task<PersonOutDTO?> createPersonAsync(CreatePersonDTO personDTO);
        Task<PersonOutDTO?> updatePersonByIdAsync(int id_person, UpdatePersonDTO updateDto);
        Task<PersonOutDTO?> deletePersonByidAsync(int id_person);
    }
}
