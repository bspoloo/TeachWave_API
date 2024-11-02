using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.SubmissionDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;

namespace TeachWaveAPI.Application.Services
{
    public class SubmissionService : ISubmissionService
    {
        private readonly ISubmissionRepository _submissionRepository;
        private readonly IMapper _mapper;

        public SubmissionService(ISubmissionRepository submissionRepository, IMapper mapper)
        {
            _submissionRepository = submissionRepository;
            _mapper = mapper;
        }
        public async Task<SubmissionOutDTO?> createSubmissionAsync(CreateSubmissionDTO createDTO)
        {
            var submission = _mapper.Map<Submission>(createDTO);
            var result = await _submissionRepository.AddAsync(submission);
            return _mapper.Map<SubmissionOutDTO>(result);
        }

        public async Task<SubmissionOutDTO?> deleteSubmissionByidAsync(int id)
        {
            var result = await _submissionRepository.DeleteAsync(id);
            return _mapper.Map<SubmissionOutDTO>(result);
        }

        public async Task<IEnumerable<SubmissionOutDTO>> getAllSubmissionsAsync()
        {
            var results = await _submissionRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<SubmissionOutDTO>>(results);
        }

        public async Task<SubmissionOutDTO?> getSubmissionByIdAsync(int id)
        {
            var submission = await _submissionRepository.GetByIdAsync(id);
            return _mapper.Map<SubmissionOutDTO>(submission);
        }

        public async Task<SubmissionOutDTO?> updateSubmissionByIdAsync(int id, UpdateSubmissionDTO updateDto)
        {
            var existingSubmission = await _submissionRepository.GetByIdAsync(id);
            if (existingSubmission == null)
            {
                return null;
            }
            _mapper.Map(updateDto, existingSubmission);
            var updated = await _submissionRepository.UpdateAsync(id, existingSubmission);
            return _mapper.Map<SubmissionOutDTO>(updated);
        }
    }
}
