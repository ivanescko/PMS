using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="UserAccessRole"/>
    /// </summary>
    public class UserAccessRoleConfiguration : IEntityTypeConfiguration<UserAccessRole>
    {
        /// <summary>
        /// Конфигурация таблицы UserAccessRole
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<UserAccessRole> builder)
        {
            // Table
            builder.ToTable("UserAccessRole", "pms");

            // PK
            builder.HasKey(e => new { e.AccessRoleID, e.UserID });

            // AccessRoleID (PK)
            builder
                .HasOne(e => e.AccessRole)
                .WithMany(ar => ar.UserAccessRoles)
                .HasForeignKey(e => e.AccessRoleID);

            // UserID (PK)
            builder
                .HasOne(e => e.User)
                .WithMany(u => u.UserAccess)
                .HasForeignKey(e => e.UserID);

        }
    }
}
