using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.AssignmentDTO;
using TeachWaveAPI.Application.DTOs.CourseDTO;
using TeachWaveAPI.Application.DTOs.EnrollmentsDTO;
using TeachWaveAPI.Application.DTOs.ModuleDTO;
using TeachWaveAPI.Application.DTOs.PersonDTO;
using TeachWaveAPI.Application.DTOs.SubmissionDTO;
using TeachWaveAPI.Application.DTOs.UserDTO;
using TeachWaveAPI.Core.Entities;

namespace TeachWaveAPI.Application.Mappings
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, CreatePersonDTO>();
            CreateMap<CreatePersonDTO, User>();

            CreateMap<PersonOutDTO, User>();
            CreateMap<User, PersonOutDTO>();

            CreateMap<User, UpdatePersonDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
            CreateMap<UpdatePersonDTO, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));


            CreateMap<User, CreateUserDTO>();
            CreateMap<CreateUserDTO, User>();

            CreateMap<UserOutDTO, User>();
            CreateMap<User, UserOutDTO>();

            CreateMap<User, UpdateUserDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
            CreateMap<UpdateUserDTO, User>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));


            CreateMap<Course, CreateCourseDTO>();
            CreateMap<CreateCourseDTO, Course>();

            CreateMap<CourseOutDTO, Course>();
            CreateMap<Course, CourseOutDTO>();

            CreateMap<Course, UpdateCourseDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
            CreateMap<UpdateCourseDTO, Course>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));


            CreateMap<CourseModule, CreateModuleDTO>();
            CreateMap<CreateModuleDTO, CourseModule>();

            CreateMap<ModuleOutDTO, CourseModule>();
            CreateMap<CourseModule, ModuleOutDTO>();

            CreateMap<CourseModule, UpdateModuleDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
            CreateMap<UpdateModuleDTO, CourseModule>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));


            CreateMap<Enrollment, CreateEnrollmentDTO>();
            CreateMap<CreateEnrollmentDTO, Enrollment>();

            CreateMap<EnrollmentOutDTO, Enrollment>();
            CreateMap<Enrollment, EnrollmentOutDTO>();

            CreateMap<Enrollment, UpdateEnrollmentDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
            CreateMap<UpdateEnrollmentDTO, Enrollment>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));


            CreateMap<Assignment, CreateAssignmentDTO>();
            CreateMap<CreateAssignmentDTO, Assignment>();

            CreateMap<AssignmentOutDTO, Assignment>();
            CreateMap<Assignment, AssignmentOutDTO>();

            CreateMap<Assignment, UpdateAssignmentDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
            CreateMap<UpdateAssignmentDTO, Assignment>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));

            CreateMap<Submission, CreateSubmissionDTO>();
            CreateMap<CreateSubmissionDTO, Submission>();

            CreateMap<SubmissionOutDTO, Submission>();
            CreateMap<Submission, SubmissionOutDTO>();

            CreateMap<Submission, UpdateSubmissionDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
            CreateMap<UpdateSubmissionDTO, Submission>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
        }
    }
}
