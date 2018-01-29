using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using ddcCajamarca.Models;

namespace ddcCajamarca.Repository.Mapping
{
    public class webpages_RolMap : EntityTypeConfiguration<webpages_Rol>
    {
        public webpages_RolMap()
        {
            this.HasKey(c => c.RoleId);

            this.Property(c => c.RoleId)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            this.Property(p => p.RoleName).IsRequired();

            this.ToTable("webpages_Roles");
            this.Property(c => c.RoleId).HasColumnName("RoleId");
            this.Property(c => c.RoleName).HasColumnName("RoleName");
        }
    }
}
