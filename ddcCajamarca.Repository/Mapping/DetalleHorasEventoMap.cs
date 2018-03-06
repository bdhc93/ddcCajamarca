using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class DetalleHorasEventoMap : EntityTypeConfiguration<DetalleHorasEvento>
    {
        public DetalleHorasEventoMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdEventoEnsayo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.FechaInicio).IsRequired().HasColumnType("datetime2");
            this.Property(p => p.FechaFin).IsRequired().HasColumnType("datetime2");
            //this.Property(p => p.Estado).IsOptional();

            this.ToTable("DetalleHorasEvento");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdEventoEnsayo).HasColumnName("IdEventoEnsayo");
            this.Property(c => c.FechaInicio).HasColumnName("FechaInicio");
            this.Property(c => c.FechaFin).HasColumnName("FechaFin");
            //this.Property(c => c.Estado).HasColumnName("Estado");

            this.HasRequired(h => h.EventoEnsayo)
                .WithMany(h => h.DetalleHorasEventos)
                .HasForeignKey(p => p.IdEventoEnsayo)
                .WillCascadeOnDelete(true);
            

        }
    }
}
