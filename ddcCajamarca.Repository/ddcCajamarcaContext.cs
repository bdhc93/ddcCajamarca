using System.Data.Entity;
using ddcCajamarca.Models;
using ddcCajamarca.Repository.Mapping;

namespace ddcCajamarca.Repository
{
    public class ddcCajamarcaContext : DbContext
    {
        public ddcCajamarcaContext()
        {
            //Database.SetInitializer<ddcCajamarcaContext>(new DropCreateDatabaseAlways<ddcCajamarcaContext>());
            //Database.SetInitializer<ddcCajamarcaContext>(new CreateDatabaseIfNotExists<ddcCajamarcaContext>());
            Database.SetInitializer<ddcCajamarcaContext>(null);
        }

        public DbSet<Persona> Personas { get; set; }
        public DbSet<OcupacionCultural> OcupacionCulturales { get; set; }
        public DbSet<Organizacion> Organizaciones { get; set; }
        public DbSet<Profesion> Profesiones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new PersonaMap());
            modelBuilder.Configurations.Add(new OcupacionCulturalMap());
            modelBuilder.Configurations.Add(new OrganizacionMap());
            modelBuilder.Configurations.Add(new ProfesionMap());
        }
    }
}
