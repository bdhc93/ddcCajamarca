using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class EventoEnsayoMap : EntityTypeConfiguration<EventoEnsayo>
    {
        public EventoEnsayoMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdAmbiente)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.NombreActividad).IsRequired();
            this.Property(p => p.InstitucionEncargada).IsOptional();
            this.Property(p => p.InformacionAdicional).IsOptional();
            this.Property(p => p.TodoDia).IsOptional();
            this.Property(p => p.FechaInicio).IsRequired().HasColumnType("datetime2");
            this.Property(p => p.FechaFin).IsRequired().HasColumnType("datetime2");
            this.Property(p => p.FechaRegistro).IsRequired().HasColumnType("datetime2");

            this.ToTable("EventoEnsayo");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdAmbiente).HasColumnName("IdAmbiente");
            this.Property(c => c.NombreActividad).HasColumnName("NombreActividad");
            this.Property(c => c.InstitucionEncargada).HasColumnName("InstitucionEncargada");
            this.Property(c => c.TodoDia).HasColumnName("TodoDia");
            this.Property(c => c.FechaFin).HasColumnName("FechaFin");
            this.Property(c => c.FechaRegistro).HasColumnName("FechaRegistro");
            this.Property(c => c.FechaInicio).HasColumnName("FechaInicio");
            
            this.HasRequired(h => h.Ambiente)
                .WithMany(h => h.EventoEnsayos)
                .HasForeignKey(p => p.IdAmbiente)
                .WillCascadeOnDelete(false);

        }
    }
}
