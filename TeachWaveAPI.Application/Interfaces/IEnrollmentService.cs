using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.EnrollmentsDTO;

namespace TeachWaveAPI.Application.Interfaces
{
    public interface IEnrollmentService
    {
        Task<IEnumerable<EnrollmentOutDTO>> getAllEnrollmentsAsync();
        Task<EnrollmentOutDTO?> getEnrollmentByIdAsync(int id);
        Task<EnrollmentOutDTO?> createEnrollmentAsync(CreateEnrollmentDTO createDTO);
        Task<EnrollmentOutDTO?> updateEnrollmentByIdAsync(int id, UpdateEnrollmentDTO updateDto);
        Task<EnrollmentOutDTO?> deleteEnrollmentByidAsync(int id);
    }
}
