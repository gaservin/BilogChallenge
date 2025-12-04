using BilogChallenge.Application.Interfaces.Repositories;
using BilogChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilogChallenge.Infrastructure.Persistence.Repositories
{
    public class SpecialtyRepository : ISpecialtyRepository
    {
        private readonly BilogDbContext _dbContext;

        public SpecialtyRepository( BilogDbContext dbContext )
        {
            _dbContext = dbContext;
        }

        public Task AddAsync( Especialidad especialidad )
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync( int id )
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Especialidad>> GetAllAsync()
        {
            return await _dbContext.especialidades.ToListAsync();
        }

        public Task<Especialidad?> GetByIdAsync( int id )
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync( Especialidad especialidad )
        {
            throw new NotImplementedException();
        }
    }
}