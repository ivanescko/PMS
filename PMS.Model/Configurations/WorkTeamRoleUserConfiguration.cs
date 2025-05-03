using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="WorkTeamRoleUser"/>
    /// </summary>
    public class WorkTeamRoleUserConfiguration : IEntityTypeConfiguration<WorkTeamRoleUser>
    {
        /// <summary>
        /// Конфигурация таблицы WorkTeamRoleUser
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<WorkTeamRoleUser> builder)
        {
            // Table
            builder.ToTable("WorkTeamRoleUser", "pms");

            // PK
            builder.HasKey(e => new { e.UserID, e.WorkTeamID, e.WorkTeamRoleID });

            // UserID (PK)
            builder
                .HasOne(e => e.User)
                .WithMany(u => u.WorkTeams)
                .HasForeignKey(e => e.UserID);

            // WorkTeamID (PK)
            builder
                .HasOne(e => e.WorkTeam)
                .WithMany(wt => wt.WorkTeams)
                .HasForeignKey(e => e.WorkTeamID);

            // WorkTeamRoleID (FK)
            builder
                .HasOne(e => e.WorkTeamRole)
                .WithMany(wt => wt.WorkTeams)
                .HasForeignKey(e => e.WorkTeamRoleID);
        }
    }
}
