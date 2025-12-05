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

        public async Task AddAsync( Especialidad especialidad )
        {
            if ( especialidad == null ) throw new ArgumentNullException( nameof(especialidad), "El objeto especialidad no puede ser null." );

            await _dbContext.AddAsync( especialidad );
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync( int id )
        {
            var specialty = await _dbContext.especialidades.FindAsync( id );
            if ( specialty != null )
            {
                _dbContext.especialidades.Remove( specialty );
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Especialidad>> GetAllAsync()
        {
            return await _dbContext.especialidades.ToListAsync();
        }

        public async Task<Especialidad?> GetByIdAsync( int id )
        {
            return await _dbContext.especialidades.FindAsync( id );
        }

        public async Task<Especialidad?> UpdateAsync( Especialidad especialidad )
        {
            if ( especialidad == null ) throw new ArgumentNullException( nameof(especialidad), "El objeto especialidad no puede ser null." );

            var existingSpecialty = await _dbContext.especialidades.FirstOrDefaultAsync( e => e.id_especialidad == especialidad.id_especialidad );

            if ( existingSpecialty == null ) return null;

            existingSpecialty.cod_especialidad = especialidad.cod_especialidad;
            existingSpecialty.descripcion      = especialidad.descripcion;

            await _dbContext.SaveChangesAsync();
            return existingSpecialty;
        }

        public async Task<bool> ExistsByCodeOrDescriptionAsync( string codEspecialidad, string descripcion )
        {
            return await _dbContext.especialidades.AnyAsync( p => p.cod_especialidad == codEspecialidad || p.descripcion == descripcion );
        }

        public async Task<bool> ExistsByCodeOrDescriptionIdAsync( int? idEspecialidad, string codEspecialidad, string descripcion )
        {
            IQueryable<Especialidad> query = _dbContext.especialidades;

            if ( idEspecialidad.HasValue && idEspecialidad > 0 ) query = query.Where( p => p.id_especialidad != idEspecialidad );

            return await query.AnyAsync( p => p.cod_especialidad == codEspecialidad || p.descripcion == descripcion );
        }
    }
}