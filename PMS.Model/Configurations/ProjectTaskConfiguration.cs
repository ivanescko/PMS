using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="ProjectTask"/>
    /// </summary>
    public class ProjectTaskConfiguration : IEntityTypeConfiguration<ProjectTask>
    {
        /// <summary>
        /// Конфигурация таблицы ProjectTask
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<ProjectTask> builder)
        {
            // Table
            builder.ToTable("ProjectTask", "pms");

            // PK
            builder.HasKey(e => e.ProjectTaskID);

            // ProjectTaskID
            builder.Property(e => e.ProjectTaskID)
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

            // StartDate
            builder.Property(e => e.StartDate)
                .HasColumnType("date");

            // EndDate
            builder.Property(e => e.EndDate)
                .HasColumnType("date");

            // CreatedByUserID (FK)
            builder.Property(e => e.CreatedByUserID)
                .IsRequired();

            builder
                .HasOne(e => e.CreatedByUser)
                .WithMany(cu => cu.CreatedProjectTasks)
                .HasForeignKey(e => e.CreatedByUserID);

            // ProjectReleaseID (FK)
            builder
                .HasOne(e => e.ProjectRelease)
                .WithMany(pr => pr.ProjectTasks)
                .HasForeignKey(e => e.ProjectReleaseID);

            // ResponsibleUserID (FK)
            builder.Property(e => e.ResponsibleUserID)
                .IsRequired(false);

            builder
                .HasOne(e => e.ResponsibleUser)
                .WithMany(ru => ru.ResponsibleForTasks)
                .HasForeignKey(e => e.ResponsibleUserID);

            // ExecutorUserID (FK)
            builder.Property(e => e.ExecutorUserID)
                .IsRequired(false);

            builder
                .HasOne(e => e.ExecutorUser)
                .WithMany(eu => eu.TasksExecutedBy)
                .HasForeignKey(e => e.ExecutorUserID);

            // ProjectTaskStatusID (FK)
            builder
                .HasOne(e => e.ProjectTaskStatus)
                .WithMany(pts => pts.ProjectTasks)
                .HasForeignKey(e => e.ProjectTaskStatusID);

            // ProjectTaskCategoryID (FK)
            builder.Property(e => e.ProjectTaskCategoryID)
                .IsRequired(false);

            builder
                .HasOne(e => e.ProjectTaskCategory)
                .WithMany(ptc => ptc.ProjectTasks)
                .HasForeignKey(e => e.ProjectTaskCategoryID);

            // ParentTaskID (FK)
            builder.Property(e => e.ParentTaskID)
                .IsRequired(false);

            builder
                .HasOne(e => e.ParentTask)
                .WithMany(pt => pt.Subtasks)
                .HasForeignKey(e => e.ParentTaskID);
        }
    }
}
