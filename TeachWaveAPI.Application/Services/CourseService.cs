using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Core.Entities;
using TeachWaveAPI.Core.Interfaces;

namespace TeachWaveAPI.Application.Services
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepositoy;
        private readonly IMapper _mapper;

        public CourseService(ICourseRepository courseRepositoy, IMapper mapper)
        {
            _courseRepositoy = courseRepositoy;
            _mapper = mapper;
        }

        public async Task<CourseOutDTO?> createCoursenAsync(CreateCourseDTO createDTO)
        {
            var course = _mapper.Map<Course>(createDTO);
            var result = await _courseRepositoy.AddAsync(course);
            return _mapper.Map<CourseOutDTO>(result);
        }

        public async Task<CourseOutDTO?> deleteCourseByidAsync(int id)
        {
            var result = await _courseRepositoy.DeleteAsync(id);
            return _mapper.Map<CourseOutDTO>(result);
        }

        public async Task<IEnumerable<CourseOutDTO>> getAllCoursesAsync()
        {
            var results = await _courseRepositoy.GetAllAsync();
            return _mapper.Map<IEnumerable<CourseOutDTO>>(results);
        }

        public async Task<CourseOutDTO?> getCoursesByIdAsync(int id)
        {
            var course = await _courseRepositoy.GetByIdAsync(id);
            return _mapper.Map<CourseOutDTO>(course);
        }

        public async Task<CourseOutDTO?> updateCourseByIdAsync(int id, UpdateCourseDTO updateDto)
        {
            var existingCourse = await _courseRepositoy.GetByIdAsync(id);
            if (existingCourse == null)
            {
                return null;
            }
            _mapper.Map(updateDto, existingCourse);
            var updated = await _courseRepositoy.UpdateAsync(id, existingCourse);
            return _mapper.Map<CourseOutDTO>(updated);
        }
    }
}
