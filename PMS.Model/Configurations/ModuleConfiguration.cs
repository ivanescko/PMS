using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Module"/>
    /// </summary>
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        /// <summary>
        /// Конфигурация таблицы Module
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            // Table
            builder.ToTable("Module", "pms");

            // PK
            builder.HasKey(e => e.ModuleID);

            // ModuleID
            builder.Property(e => e.ModuleID)
                .UseIdentityColumn();

            // Title
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
