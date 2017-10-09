using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class PersonaMap : EntityTypeConfiguration<Persona>
    {
        public PersonaMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdOcupacionCultural)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(c => c.IdOrganizacion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            this.Property(c => c.IdProfesion)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.NombreArtistico).IsOptional();
            this.Property(p => p.NombreApellidos).IsRequired();
            this.Property(p => p.Direccion).IsOptional();
            this.Property(p => p.Telefono).IsRequired();
            this.Property(p => p.FechaRegistro).IsRequired().HasColumnType("datetime2");
            this.Property(p => p.FechaNacimiento).IsOptional().HasColumnType("datetime2");
            this.Property(p => p.Email).IsOptional();
            this.Property(p => p.Imagen).IsOptional();
            this.Property(p => p.RedesSociales).IsOptional();
            this.Property(p => p.Cargo).IsOptional();

            this.ToTable("Persona");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdOrganizacion).HasColumnName("IdOrganizacion");
            this.Property(c => c.IdOcupacionCultural).HasColumnName("IdOcupacionCultural");
            this.Property(c => c.IdProfesion).HasColumnName("IdProfesion");
            this.Property(c => c.NombreArtistico).HasColumnName("NombreArtistico");
            this.Property(c => c.NombreApellidos).HasColumnName("NombreApellidos");
            this.Property(c => c.Direccion).HasColumnName("Direccion");
            this.Property(c => c.Telefono).HasColumnName("Telefono");
            this.Property(c => c.FechaRegistro).HasColumnName("FechaRegistro");
            this.Property(c => c.FechaNacimiento).HasColumnName("FechaNacimiento");
            this.Property(c => c.Email).HasColumnName("Email");
            this.Property(c => c.Imagen).HasColumnName("Imagen");
            this.Property(c => c.RedesSociales).HasColumnName("RedesSociales");
            this.Property(c => c.Cargo).HasColumnName("Cargo");

            this.HasRequired(h => h.OcupacionCultural)
                .WithMany(h => h.Personas)
                .HasForeignKey(p => p.IdOcupacionCultural)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Profesion)
                .WithMany(h => h.Personas)
                .HasForeignKey(p => p.IdProfesion)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.Organizacion)
                .WithMany(h => h.Personas)
                .HasForeignKey(p => p.IdOrganizacion)
                .WillCascadeOnDelete(false);
        }
    }
}
