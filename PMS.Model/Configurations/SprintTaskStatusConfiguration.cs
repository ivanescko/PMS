using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="SprintTaskStatus"/>
    /// </summary>
    public class SprintTaskStatusConfiguration : IEntityTypeConfiguration<SprintTaskStatus>
    {
        /// <summary>
        /// Конфигурация таблицы SprintTaskStatus
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<SprintTaskStatus> builder)
        {
            // Table
            builder.ToTable("SprintTaskStatus", "pms");

            // PK
            builder.HasKey(e => e.SprintTaskStatusID);

            // SprintTaskStatusID
            builder.Property(e => e.SprintTaskStatusID)
                .UseIdentityColumn();

            // Title
            builder.Property(e => e.Title)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}
