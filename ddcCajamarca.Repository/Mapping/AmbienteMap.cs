using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class AmbienteMap : EntityTypeConfiguration<Ambiente>
    {
        public AmbienteMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Nombre).IsRequired();
            this.Property(p => p.Aforo).IsOptional();
            this.Property(p => p.Color).IsRequired();
            this.Property(p => p.Estado).IsOptional();
            this.Property(p => p.FechaRegistro).IsRequired().HasColumnType("datetime2");

            this.ToTable("Ambiente");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Nombre).HasColumnName("Nombre");
            this.Property(c => c.Color).HasColumnName("Color");
            this.Property(c => c.Aforo).HasColumnName("Aforo");
            this.Property(c => c.FechaRegistro).HasColumnName("FechaRegistro");
            this.Property(c => c.Estado).HasColumnName("Estado");
        }
    }
}
