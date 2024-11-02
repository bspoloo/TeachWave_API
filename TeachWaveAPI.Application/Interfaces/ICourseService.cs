using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;

namespace TeachWaveAPI.Application.Interfaces
{
    public interface ICourseService
    {
        Task<IEnumerable<CourseOutDTO>> getAllCoursesAsync();
        Task<CourseOutDTO?> getCoursesByIdAsync(int id);
        Task<CourseOutDTO?> createCoursenAsync(CreateCourseDTO createDTO);
        Task<CourseOutDTO?> updateCourseByIdAsync(int id, UpdateCourseDTO updateDto);
        Task<CourseOutDTO?> deleteCourseByidAsync(int id);
    }
}
