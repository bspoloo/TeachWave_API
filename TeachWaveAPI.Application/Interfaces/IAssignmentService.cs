using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.AssignmentDTO;

namespace TeachWaveAPI.Application.Interfaces
{
    public interface IAssignmentService
    {
        Task<IEnumerable<AssignmentOutDTO>> getAllAssignmentsAsync();
        Task<AssignmentOutDTO?> getAssignmentByIdAsync(int id);
        Task<AssignmentOutDTO?> createAssignmentAsync(CreateAssignmentDTO createDTO);
        Task<AssignmentOutDTO?> updateAssignmentByIdAsync(int id, UpdateAssignmentDTO updateDto);
        Task<AssignmentOutDTO?> deleteAssignmentByidAsync(int id);
    }
}
