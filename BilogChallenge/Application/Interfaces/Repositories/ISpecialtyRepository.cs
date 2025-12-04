using BilogChallenge.Domain.Entities;

namespace BilogChallenge.Application.Interfaces.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<Especialidad?> GetByIdAsync( int id );
        Task<IEnumerable<Especialidad>> GetAllAsync();
        Task AddAsync   ( Especialidad especialidad );
        Task UpdateAsync( Especialidad especialidad );
        Task DeleteAsync( int id );
    }
}