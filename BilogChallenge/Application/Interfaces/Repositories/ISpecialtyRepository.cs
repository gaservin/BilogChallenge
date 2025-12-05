using BilogChallenge.Domain.Entities;

namespace BilogChallenge.Application.Interfaces.Repositories
{
    public interface ISpecialtyRepository
    {
        Task<Especialidad?> GetByIdAsync( int id );
        Task<IEnumerable<Especialidad>> GetAllAsync();
        Task<Especialidad?> UpdateAsync( Especialidad especialidad );
        Task AddAsync   ( Especialidad especialidad );
        Task DeleteAsync( int id );
        Task<bool> ExistsByCodeOrDescriptionAsync( string codEspecialidad, string descripcion );
        Task<bool> ExistsByCodeOrDescriptionIdAsync( int? id, string codEspecialidad, string descripcion );
    }
}