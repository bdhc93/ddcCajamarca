using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class PerfilUsuarioMap : EntityTypeConfiguration<PerfilUsuario>
    {
        public PerfilUsuarioMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.Usuario).IsRequired();
            this.Property(p => p.NombreApellidos).IsOptional();
            this.Property(p => p.NombreMostrar).IsOptional();
            this.Property(p => p.Email).IsOptional();
            this.Property(p => p.Imagen).IsOptional();

            this.ToTable("PerfilUsuario");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.Usuario).HasColumnName("Usuario");
            this.Property(c => c.NombreApellidos).HasColumnName("NombreApellidos");
            this.Property(c => c.NombreMostrar).HasColumnName("NombreMostrar");
            this.Property(c => c.Email).HasColumnName("Email");
            this.Property(c => c.Imagen).HasColumnName("Imagen");
        }
    }
}
