using AutoMapper;
using BilogChallenge.Application.DTOs.Specialty;
using BilogChallenge.Application.Exceptions;
using BilogChallenge.Application.Interfaces.Repositories;
using BilogChallenge.Application.Interfaces.Services;
using BilogChallenge.Domain.Entities;
using System.ComponentModel.DataAnnotations;

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

        public async Task<List<SpecialtyDto>> GetAllSpecialtiesAsync()
        {
            var specialities = await _specialtyRepository.GetAllAsync();
            return _mapper.Map<List<SpecialtyDto>>( specialities );
        }

        public async Task<SpecialtyDto?> GetByIdSpecialtyAsync( int id )
        {
            var specialty = await _specialtyRepository.GetByIdAsync( id );
            return _mapper.Map<SpecialtyDto>( specialty );
        }

        public async Task<SpecialtyDto> AddSpecialtyAsync( CreateSpecialtyDto specialty )
        {
            if ( await _specialtyRepository.ExistsByCodeOrDescriptionAsync( specialty.cod_especialidad, specialty.descripcion ) )
            {
                throw new DuplicateException( "Código o descripción duplicados" );
            }

            if ( string.IsNullOrWhiteSpace( specialty.cod_especialidad ) ) throw new ValidationException( "El cod_especialidad es obligatorio." );

            if ( string.IsNullOrWhiteSpace( specialty.descripcion ) ) throw new ValidationException( "La descripción es obligatoria." );

            var newSpecialty = _mapper.Map<Especialidad>( specialty );

            await _specialtyRepository.AddAsync( newSpecialty );

            return _mapper.Map<SpecialtyDto>( newSpecialty );
        }

        public async Task<SpecialtyDto?> UpdateSpecialtyAsync( int id, UpdateSpecialtyDto specialty )
        {
            var existingSpecialty = await _specialtyRepository.GetByIdAsync( id );
            if ( existingSpecialty == null ) throw new NotFoundException( $"La especialidad con Id {id} no existe." );

            if ( string.IsNullOrWhiteSpace( specialty.cod_especialidad ) ) throw new ValidationException( "El cod_especialidad es obligatorio." );

            if ( string.IsNullOrWhiteSpace( specialty.descripcion      ) ) throw new ValidationException( "La descripción es obligatoria." );

            if ( !existingSpecialty.rowversion.SequenceEqual( specialty.rowversion ) ) throw new ConcurrencyException( "El registro ha sido modificado por otro usuario." );

            var exists = await _specialtyRepository.ExistsByCodeOrDescriptionIdAsync( id, specialty.cod_especialidad, specialty.descripcion );
            if ( exists ) throw new DuplicateException( "Código o descripción duplicados" );

            _mapper.Map( specialty, existingSpecialty );
            await _specialtyRepository.UpdateAsync( existingSpecialty );

            return _mapper.Map<SpecialtyDto>( existingSpecialty );
        }

        public async Task DeleteSpecialtyAsync( int id )
        {
            var existingSpecialty = await _specialtyRepository.GetByIdAsync( id );
            if ( existingSpecialty == null ) throw new NotFoundException( $"La especialidad con Id {id} no existe." );

            await _specialtyRepository.DeleteAsync( id );
        }
    }
}