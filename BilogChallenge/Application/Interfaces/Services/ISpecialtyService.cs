using BilogChallenge.Application.DTOs.Specialty;

namespace BilogChallenge.Application.Interfaces.Services
{
    public interface ISpecialtyService
    {
        Task<List<SpecialtyDto>> GetAllSpecialtiesAsync();
        Task<SpecialtyDto?> GetByIdSpecialtyAsync( int id );
        Task<SpecialtyDto> AddSpecialtyAsync( CreateSpecialtyDto specialty );
        Task<SpecialtyDto?> UpdateSpecialtyAsync( int id, UpdateSpecialtyDto specialty );
        Task DeleteSpecialtyAsync( int id );
    }
}