using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="AccessRole"/>
    /// </summary>
    public class AccessRoleConfiguration : IEntityTypeConfiguration<AccessRole>
    {
        /// <summary>
        /// Конфигурация таблицы AccessRole
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<AccessRole> builder)
        {
            // Table
            builder.ToTable("AccessRole", "pms");

            // PK
            builder.HasKey(e => e.AccessRoleID);

            // AccessRoleID
            builder.Property(e => e.AccessRoleID)
                .UseIdentityColumn();

            // Title
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired();

            // IsActive
            builder.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
