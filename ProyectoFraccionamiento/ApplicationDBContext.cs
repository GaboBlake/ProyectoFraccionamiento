using System.Collections.Generic;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using ProyectoFraccionamiento.Entities;

namespace ProyectoFraccionamiento
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public DbSet<VehiculoEntity> Vehiculos => Set<VehiculoEntity>();
        public DbSet <VisitaEntity> Visitas => Set<VisitaEntity>();

    }
}