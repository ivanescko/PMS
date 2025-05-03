using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="WorkTeamStatus"/>
    /// </summary>
    public class WorkTeamStatusConfiguration : IEntityTypeConfiguration<WorkTeamStatus>
    {
        /// <summary>
        /// Конфигурация таблицы WorkTeamStatus
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<WorkTeamStatus> builder)
        {
            // Table
            builder.ToTable("WorkTeamStatus", "pms");

            // PK
            builder.HasKey(e => e.WorkTeamStatusID);

            // WorkTeamStatusID
            builder.Property(e => e.WorkTeamStatusID)
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
