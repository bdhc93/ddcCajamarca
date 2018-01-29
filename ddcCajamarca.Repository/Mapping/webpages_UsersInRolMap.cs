using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class webpages_UsersInRolMap : EntityTypeConfiguration<webpages_UsersInRol>
    {
        public webpages_UsersInRolMap()
        {
            this.HasKey(c => c.Id);
            this.Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(c => c.RoleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(p => p.UserId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.ToTable("webpages_UsersInRoles");
            this.Property(c => c.Id).HasColumnName("Id");
            this.Property(c => c.RoleId).HasColumnName("RoleId");
            this.Property(c => c.UserId).HasColumnName("UserId");

            this.HasRequired(h => h.webpages_Roles)
                .WithMany(h => h.webpages_UsersInRoles)
                .HasForeignKey(p => p.RoleId)
                .WillCascadeOnDelete(false);

            this.HasRequired(h => h.PerfilUsuario)
                .WithMany(h => h.webpages_UsersInRoles)
                .HasForeignKey(p => p.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}
