using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProjectTaskStatus"/>
    /// </summary>
    public class ProjectTaskStatusConfiguration : IEntityTypeConfiguration<ProjectTaskStatus>
    {
        /// <summary>
        /// Конфигурация таблицы TaskStatus
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<ProjectTaskStatus> builder)
        {
            // Table
            builder.ToTable("ProjectTaskStatus", "pms");

            // PK
            builder.HasKey(e => e.ProjectTaskStatusID);

            // ProjectTaskStatusID
            builder.Property(e => e.ProjectTaskStatusID)
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
