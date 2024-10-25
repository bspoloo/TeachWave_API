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
            CreateMap<Person, CreatePersonDTO>();
            CreateMap<CreatePersonDTO, Person>();

            CreateMap<PersonOutDTO, Person>();
            CreateMap<Person, PersonOutDTO>();

            CreateMap<Person, UpdatePersonDTO>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null));
            CreateMap<UpdatePersonDTO, Person>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) =>
                    srcMember != null)); ;

        }
    }
}
