using BilogChallenge.Application.DTOs.Specialty;

namespace BilogChallenge.Application.Interfaces.Services
{
    public interface ISpecialtyService
    {
        Task<List<SpecialtyDto>> GetAllSpecialties();
    }
}