using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class DetalleRequerimientoMap : EntityTypeConfiguration<DetalleRequerimiento>
    {
        public DetalleRequerimientoMap()
        {
            this.HasKey(c => c.Id);

            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.IdEventoEnsayo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            
            this.Property(c => c.IdActivo)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.Cantidad).IsRequired();
            this.Property(p => p.FechaRegistro).IsRequired().HasColumnType("datetime2");

            this.ToTable("DetalleRequerimiento");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.IdEventoEnsayo).HasColumnName("IdEventoEnsayo");
            this.Property(c => c.IdActivo).HasColumnName("IdActivo");
            this.Property(c => c.Cantidad).HasColumnName("Cantidad");
            this.Property(c => c.FechaRegistro).HasColumnName("FechaRegistro");

            this.HasRequired(h => h.EventoEnsayo)
                .WithMany(h => h.DetalleRequerimientos)
                .HasForeignKey(p => p.IdEventoEnsayo)
                .WillCascadeOnDelete(false);
            
            this.HasRequired(h => h.Activo)
                .WithMany(h => h.DetalleRequerimientos)
                .HasForeignKey(p => p.IdActivo)
                .WillCascadeOnDelete(false);

        }
    }
}
