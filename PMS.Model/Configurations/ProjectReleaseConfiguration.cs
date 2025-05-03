using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProjectRelease"/>
    /// </summary>
    public class ProjectReleaseConfiguration : IEntityTypeConfiguration<ProjectRelease>
    {
        /// <summary>
        /// Конфигурация таблицы ProjectRelease
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<ProjectRelease> builder)
        {
            // Table
            builder.ToTable("ProjectRelease", "pms");

            // PK
            builder.HasKey(e => e.ProjectReleaseID);

            // ProjectReleaseID
            builder.Property(e => e.ProjectReleaseID)
                .UseIdentityColumn();

            // Title
            builder.Property(e => e.Version)
                .HasMaxLength(10)
                .IsRequired();

            // ProjectID
            builder.Property(e => e.ProjectID)
                .IsRequired();

            builder
                .HasOne(e => e.Project)
                .WithMany(p => p.ProjectReleases)
                .HasForeignKey(e => e.ProjectID);
        }
    }
}
