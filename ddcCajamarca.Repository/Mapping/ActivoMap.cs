using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class ActivoMap : EntityTypeConfiguration<Activo>
    {
        public ActivoMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Nombre).IsRequired();
            this.Property(p => p.Cantidad).IsRequired();
            this.Property(p => p.Estado).IsOptional();
            this.Property(p => p.FechaRegistro).IsRequired().HasColumnType("datetime2");

            this.ToTable("Activo");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Nombre).HasColumnName("Nombre");
            this.Property(c => c.Cantidad).HasColumnName("Cantidad");
            this.Property(c => c.FechaRegistro).HasColumnName("FechaRegistro");
            this.Property(c => c.Estado).HasColumnName("Estado");
        }
    }
}
