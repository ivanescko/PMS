using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProjectCategory"/>
    /// </summary>
    public class ProjectCategoryConfiguration : IEntityTypeConfiguration<ProjectCategory>
    {
        /// <summary>
        /// Конфигурация таблицы ProjectCategory
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<ProjectCategory> builder)
        {
            // Table
            builder.ToTable("ProjectCategory", "pms");

            // PK
            builder.HasKey(e => e.ProjectCategoryID);

            // ProjectCategoryID
            builder.Property(e => e.ProjectCategoryID)
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
