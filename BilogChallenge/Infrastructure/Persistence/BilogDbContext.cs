using BilogChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BilogChallenge.Infrastructure.Persistence
{
    public class BilogDbContext : DbContext
    {
        public BilogDbContext( DbContextOptions<BilogDbContext> options ) : base( options ) { }

        public DbSet<Especialidad> especialidades { get; set; }

        protected override void OnModelCreating( ModelBuilder modelBuilder )
        {
            base.OnModelCreating( modelBuilder );

            modelBuilder.Entity<Especialidad>( entity =>
            {
                entity.ToTable( "Especialidades" );
                entity.HasKey  ( e => e.id_especialidad  );
                entity.Property( e => e.cod_especialidad ).HasMaxLength(15);
                entity.Property( e => e.descripcion      ).HasMaxLength(50);
                entity.Property( e => e.rowversion       ).IsRowVersion().IsConcurrencyToken();
            });
        }
    }
}