using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.AssignmentDTO;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;

namespace TeachWaveAPI.Application.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }
        public async Task<AssignmentOutDTO?> createAssignmentAsync(CreateAssignmentDTO createDTO)
        {
            var assignment = _mapper.Map<Assignment>(createDTO);
            var result = await _assignmentRepository.AddAsync(assignment);
            return _mapper.Map<AssignmentOutDTO>(result);
        }

        public async Task<AssignmentOutDTO?> deleteAssignmentByidAsync(int id)
        {
            var result = await _assignmentRepository.DeleteAsync(id);
            return _mapper.Map<AssignmentOutDTO>(result);
        }

        public async Task<IEnumerable<AssignmentOutDTO>> getAllAssignmentsAsync()
        {
            var results = await _assignmentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<AssignmentOutDTO>>(results);
        }

        public async Task<AssignmentOutDTO?> getAssignmentByIdAsync(int id)
        {
            var assignment = await _assignmentRepository.GetByIdAsync(id);
            return _mapper.Map<AssignmentOutDTO>(assignment);
        }

        public async Task<AssignmentOutDTO?> updateAssignmentByIdAsync(int id, UpdateAssignmentDTO updateDto)
        {
            var existingAssignment = await _assignmentRepository.GetByIdAsync(id);
            if (existingAssignment == null)
            {
                return null;
            }
            _mapper.Map(updateDto, existingAssignment);
            var updated = await _assignmentRepository.UpdateAsync(id, existingAssignment);
            return _mapper.Map<AssignmentOutDTO>(updated);
        }
    }
}
