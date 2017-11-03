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

        //Directorio
        public DbSet<Persona> Personas { get; set; }
        public DbSet<OcupacionCultural> OcupacionCulturales { get; set; }
        public DbSet<Organizacion> Organizaciones { get; set; }
        public DbSet<Profesion> Profesiones { get; set; }

        //CalendarioCultural
        public DbSet<Activo> Activos { get; set; }
        public DbSet<Ambiente> Ambientes { get; set; }
        public DbSet<DetalleRequerimiento> DetalleRequerimientos { get; set; }
        public DbSet<DetalleHorasEvento> DetalleHorasEventos { get; set; }
        public DbSet<EventoEnsayo> EventoEnsayos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Directorio
            modelBuilder.Configurations.Add(new PersonaMap());
            modelBuilder.Configurations.Add(new OcupacionCulturalMap());
            modelBuilder.Configurations.Add(new OrganizacionMap());
            modelBuilder.Configurations.Add(new ProfesionMap());

            //CalendarioCultural
            modelBuilder.Configurations.Add(new ActivoMap());
            modelBuilder.Configurations.Add(new AmbienteMap());
            modelBuilder.Configurations.Add(new DetalleRequerimientoMap());
            modelBuilder.Configurations.Add(new DetalleHorasEventoMap());
            modelBuilder.Configurations.Add(new EventoEnsayoMap());
        }
    }
}
