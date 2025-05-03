using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="ModuleAccessRole"/>
    /// </summary>
    public class ModuleAccessRoleConfiguration : IEntityTypeConfiguration<ModuleAccessRole>
    {
        /// <summary>
        /// Конфигурация таблицы ModuleAccessRole
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<ModuleAccessRole> builder)
        {
            // Table
            builder.ToTable("ModuleAccessRole", "pms");

            // PK
            builder.HasKey(e => new { e.AccessRoleID, e.ModuleID });

            // AccessRoleID (FK)
            builder.Property(e => e.AccessRoleID);

            builder
                .HasOne(e => e.AccessRole)
                .WithMany(ar => ar.ModuleAccessRoles)
                .HasForeignKey(e => e.AccessRoleID);

            // ModuleID (FK)
            builder.Property(e => e.ModuleID);

            builder
                .HasOne(e => e.Module)
                .WithMany(m => m.ModuleAccessRoles)
                .HasForeignKey(e => e.ModuleID);

            // Create
            builder.Property(e => e.Create)
                .HasDefaultValue(false)
                .IsRequired();

            // Read
            builder.Property(e => e.Read)
                .HasDefaultValue(false)
                .IsRequired();

            // Update
            builder.Property(e => e.Update)
                .HasDefaultValue(false)
                .IsRequired();

            // Delete
            builder.Property(e => e.Delete)
                .HasDefaultValue(false)
                .IsRequired();
        }
    }
}
