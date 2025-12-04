using AutoMapper;
using BilogChallenge.Application.DTOs.Specialty;
using BilogChallenge.Domain.Entities;

namespace BilogChallenge.Application.Mapping
{
    public class ApplicationMappingProfile : Profile
    {
        public ApplicationMappingProfile()
        {
            CreateMap<Especialidad, SpecialtyDto>();
            CreateMap<SpecialtyDto, Especialidad>();
            CreateMap<Especialidad, CreateSpecialtyDto>();
            CreateMap<CreateSpecialtyDto, Especialidad>();
            CreateMap<Especialidad, UpdateSpecialtyDto>();
            CreateMap<UpdateSpecialtyDto, Especialidad>();
        }
    }
}