using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Project"/>
    /// </summary>
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        /// <summary>
        /// Конфигурация таблицы Project
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // Table
            builder.ToTable("Project", "pms");

            // PK
            builder.HasKey(e => e.ProjectID);

            // ProjectID
            builder.Property(e => e.ProjectID)
                .UseIdentityColumn();

            // Title
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired();

            // Description
            builder.Property(e => e.Description)
                .HasMaxLength(200);

            // CreatedDate
            builder.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .IsRequired();

            // EstimtedStartDate
            builder.Property(e => e.EstimatedStartDate)
                .HasColumnType("date");

            // ActualStartDate
            builder.Property(e => e.ActualStartDate)
                .HasColumnType("date");

            // EstimatedEndDate
            builder.Property(e => e.EstimatedEndDate)
                .HasColumnType("date");

            // ActualEndDate
            builder.Property(e => e.ActualEndDate)
                .HasColumnType("date");

            // CreatedByUserID (FK)
            builder.Property(e => e.CreatedByUserID)
                .IsRequired();

            builder
                .HasOne(e => e.CreatedByUser)
                .WithMany(cu => cu.CreatedProjects)
                .HasForeignKey(e => e.CreatedByUserID);

            // ManagerID (FK)
            builder.Property(e => e.ManagerID)
                .IsRequired();

            builder
                .HasOne(e => e.Manager)
                .WithMany(cu => cu.ManagedProjects)
                .HasForeignKey(e => e.ManagerID);

            // ProjectStatusID (FK)
            builder.Property(e => e.ProjectStatusID)
                .IsRequired();

            builder
                .HasOne(e => e.ProjectStatus)
                .WithMany(cu => cu.Projects)
                .HasForeignKey(e => e.ProjectStatusID);

            // ProjectCategoryID (FK)
            builder
                .HasOne(e => e.ProjectCategory)
                .WithMany(cu => cu.Projects)
                .HasForeignKey(e => e.ProjectCategoryID);
        }
    }
}
