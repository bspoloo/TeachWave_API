using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeachWaveAPI.Application.DTOs.PersonDTO;
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
                    srcMember != null)); ;

        }
    }
}
