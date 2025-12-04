using AutoMapper;
using BilogChallenge.Application.DTOs.Specialty;
using BilogChallenge.Application.Interfaces.Repositories;
using BilogChallenge.Application.Interfaces.Services;

namespace BilogChallenge.Application.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly ISpecialtyRepository _specialtyRepository;
        private readonly IMapper _mapper;
        public SpecialtyService( ISpecialtyRepository specialtyRepository, IMapper mapper ) 
        { 
            _specialtyRepository = specialtyRepository;
            _mapper = mapper;
        }
        public async Task<List<SpecialtyDto>> GetAllSpecialties()
        {
            var specialities = await _specialtyRepository.GetAllAsync();
            return _mapper.Map<List<SpecialtyDto>>( specialities );
        }
    }
}