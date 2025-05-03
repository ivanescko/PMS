using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProjectTaskCategory"/>
    /// </summary>
    public class ProjectTaskCategoryConfiguration : IEntityTypeConfiguration<ProjectTaskCategory>
    {
        /// <summary>
        /// Конфигурация таблицы ProjectTaskCategory
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<ProjectTaskCategory> builder)
        {
            // Table
            builder.ToTable("ProjectTaskCategory", "pms");

            // PK
            builder.HasKey(e => e.ProjectTaskCategoryID);

            // ProjectTaskCategoryID
            builder.Property(e => e.ProjectTaskCategoryID)
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
