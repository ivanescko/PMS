using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProjectStatus"/>
    /// </summary>
    public class ProjectStatusConfiguration : IEntityTypeConfiguration<ProjectStatus>
    {
        /// <summary>
        /// Конфигурация таблицы ProjectStatus
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<ProjectStatus> builder)
        {
            // Table
            builder.ToTable("ProjectStatus", "pms");

            // PK
            builder.HasKey(e => e.ProjectStatusID);

            // ProjectStatusID
            builder.Property(e => e.ProjectStatusID)
                .UseIdentityColumn();

            // Title
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired();

            // Description
            builder.Property(e => e.Description)
                .HasMaxLength(200);
        }
    }
}
