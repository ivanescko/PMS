using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="SprintTask"/>
    /// </summary>
    public class SprintTaskConfiguration : IEntityTypeConfiguration<SprintTask>
    {
        /// <summary>
        /// Конфигурация таблицы SprintTask
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<SprintTask> builder)
        {
            // Table
            builder.ToTable("SprintTask", "pms");

            // PK
            builder.HasKey(e => new { e.SprintID, e.ProjectTaskID });

            // SprintTaskStatusID
            builder
                .HasOne(e => e.SprintTaskStatus)
                .WithMany(sts => sts.SprintTasks)
                .HasForeignKey(e => e.SprintTaskStatusID);
        }
    }
}
