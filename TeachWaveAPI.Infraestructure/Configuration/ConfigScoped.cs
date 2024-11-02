using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.Interfaces;
using TeachWaveAPI.Application.Services;
using TeachWaveAPI.Core.Interfaces;
using TeachWaveAPI.Infraestructure.Persistence.Repositories;

namespace TeachWaveAPI.Infraestructure.Configuration
{
    public class ConfigScoped
    {
        public static void AddScopedServices(IServiceCollection service)
        {
            service.AddScoped<IPersonService, PersonService>();
            service.AddScoped<IPersonRepository, PersonRepository>();

            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IUserRepository, UserRepository>();

            service.AddScoped<ICourseService, CourseService>();
            service.AddScoped<ICourseRepository, CourseRepository>();

            service.AddScoped<IModuleService, ModuleService>();
            service.AddScoped<IModuleRepository, ModuleRepository>();

            service.AddScoped<IEnrollmentService, EnrollmentService>();
            service.AddScoped<IEnrollmentRepository, EnrollmentRepository>();

            service.AddScoped<IAssignmentService, AssignmentService>();
            service.AddScoped<IAssignmentRepository, AssigmentRepository>();

            service.AddScoped<ISubmissionService, SubmissionService>();
            service.AddScoped<ISubmissionRepository, SubmissionRepositoy>();
        }
    }
}
