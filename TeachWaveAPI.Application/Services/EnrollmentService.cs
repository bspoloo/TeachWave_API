using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.EnrollmentsDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;

namespace TeachWaveAPI.Application.Services
{
    public class EnrollmentService : IEnrollmentService
    {
        private readonly IEnrollmentRepository _enrollmentRepository;
        private readonly IMapper _mapper;

        public EnrollmentService(IEnrollmentRepository enrollmentRepository, IMapper mapper)
        {
            _enrollmentRepository = enrollmentRepository;
            _mapper = mapper;
        }
        public async Task<EnrollmentOutDTO?> createEnrollmentAsync(CreateEnrollmentDTO createDTO)
        {
            var enrollment = _mapper.Map<Enrollment>(createDTO);
            var result = await _enrollmentRepository.AddAsync(enrollment);
            return _mapper.Map<EnrollmentOutDTO>(result);
        }

        public async Task<EnrollmentOutDTO?> deleteEnrollmentByidAsync(int id)
        {
            var result = await _enrollmentRepository.DeleteAsync(id);
            return _mapper.Map<EnrollmentOutDTO>(result);
        }

        public async Task<IEnumerable<EnrollmentOutDTO>> getAllEnrollmentsAsync()
        {
            var results = await _enrollmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<EnrollmentOutDTO>>(results);
        }

        public async Task<EnrollmentOutDTO?> getEnrollmentByIdAsync(int id)
        {
            var course = await _enrollmentRepository.GetByIdAsync(id);
            return _mapper.Map<EnrollmentOutDTO>(course);
        }

        public async Task<EnrollmentOutDTO?> updateEnrollmentByIdAsync(int id, UpdateEnrollmentDTO updateDto)
        {
            var existingEnrollment = await _enrollmentRepository.GetByIdAsync(id);
            if (existingEnrollment == null)
            {
                return null;
            }
            _mapper.Map(updateDto, existingEnrollment);
            var updated = await _enrollmentRepository.UpdateAsync(id, existingEnrollment);
            return _mapper.Map<EnrollmentOutDTO>(updated);
        }
    }
}
