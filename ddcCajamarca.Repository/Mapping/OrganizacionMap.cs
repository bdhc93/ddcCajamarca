using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class OrganizacionMap : EntityTypeConfiguration<Organizacion>
    {
        public OrganizacionMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Nombre).IsRequired();
            this.Property(p => p.FechaRegistro).IsRequired().HasColumnType("datetime2");
            this.Property(p => p.Direccion).IsOptional();
            this.Property(p => p.Estado).IsOptional();

            this.ToTable("Organizacion");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Nombre).HasColumnName("Nombre");
            this.Property(c => c.Direccion).HasColumnName("Direccion");
            this.Property(c => c.FechaRegistro).HasColumnName("FechaRegistro");
            this.Property(c => c.Estado).HasColumnName("Estado");
        }
    }
}
