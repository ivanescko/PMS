using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Sprint"/>
    /// </summary>
    public class SprintConfiguration : IEntityTypeConfiguration<Sprint>
    {
        /// <summary>
        /// Конфигурация таблицы Sprint
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<Sprint> builder)
        {
            // Table
            builder.ToTable("Sprint", "pms");

            // PK
            builder.HasKey(e => e.SprintID);

            // SprintID
            builder.Property(e => e.SprintID)
                .UseIdentityColumn();

            // StartDate
            builder.Property(e => e.StartDate)
                .HasColumnType("date")
                .IsRequired();

            // EndDate
            builder.Property(e => e.EndDate)
                .HasColumnType("date")
                .IsRequired();

            // Goal
            builder.Property(e => e.Goal)
                .HasMaxLength(200);

            // ProjectID (FK)
            builder
                .HasOne(e => e.Project)
                .WithMany(p => p.Sprints)
                .HasForeignKey(e => e.ProjectID);
        }
    }
}
