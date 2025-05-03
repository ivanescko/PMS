using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="WorkTeam"/>
    /// </summary>
    public class WorkTeamConfiguration : IEntityTypeConfiguration<WorkTeam>
    {
        /// <summary>
        /// Конфигурация таблицы WorkTeam
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<WorkTeam> builder)
        {
            // Table
            builder.ToTable("WorkTeam", "pms");

            // PK
            builder.HasKey(e => e.WorkTeamID);

            // WorkTeamID
            builder.Property(e => e.WorkTeamID)
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

            // CreatedByUserID (FK)
            builder
                .HasOne(e => e.CreatedByUser)
                .WithMany(u => u.CreatedWorkTeams)
                .HasForeignKey(e => e.CreatedByUserID);

            // WorkTeamStatusID (FK)
            builder.Property(e => e.WorkTeamStatusID)
                .IsRequired(false);

            builder
                .HasOne(e => e.WorkTeamStatus)
                .WithMany(wts => wts.WorkTeams)
                .HasForeignKey(e => e.WorkTeamStatusID);

            // ProjectID (FK)
            builder.Property(e => e.ProjectID)
                .IsRequired(false);

            builder
                .HasOne(e => e.Project)
                .WithOne(p => p.WorkTeam)
                .HasForeignKey<WorkTeam>(e => e.ProjectID);

            builder.HasIndex(e => e.ProjectID)
                .IsUnique();
        }
    }
}
