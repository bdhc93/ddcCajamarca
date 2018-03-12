using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class RegUsuarioMap : EntityTypeConfiguration<RegUsuario>
    {
        public RegUsuarioMap()
        {
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Usuario).IsRequired();
            this.Property(p => p.Modulo).IsRequired();
            this.Property(p => p.Cambio).IsRequired();
            this.Property(p => p.IdModulo).IsRequired();
            this.Property(p => p.Fecha).IsRequired();

            this.ToTable("RegUsuario");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Usuario).HasColumnName("Usuario");
            this.Property(c => c.Cambio).HasColumnName("Cambio");
            this.Property(c => c.IdModulo).HasColumnName("IdModulo");
            this.Property(c => c.Modulo).HasColumnName("Modulo");
            this.Property(c => c.Fecha).HasColumnName("Fecha");
        }
    }
}
