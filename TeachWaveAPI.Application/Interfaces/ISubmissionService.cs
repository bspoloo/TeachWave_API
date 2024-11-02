using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.SubmissionDTO;

namespace TeachWaveAPI.Application.Interfaces
{
    public interface ISubmissionService
    {
        Task<IEnumerable<SubmissionOutDTO>> getAllSubmissionsAsync();
        Task<SubmissionOutDTO?> getSubmissionByIdAsync(int id);
        Task<SubmissionOutDTO?> createSubmissionAsync(CreateSubmissionDTO createDTO);
        Task<SubmissionOutDTO?> updateSubmissionByIdAsync(int id, UpdateSubmissionDTO updateDto);
        Task<SubmissionOutDTO?> deleteSubmissionByidAsync(int id);
    }
}
