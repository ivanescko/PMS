using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="WorkTeamRole"/>
    /// </summary>
    public class WorkTeamRoleConfiguration : IEntityTypeConfiguration<WorkTeamRole>
    {
        /// <summary>
        /// Конфигурация таблицы WorkTeamRole
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<WorkTeamRole> builder)
        {
            // Table
            builder.ToTable("WorkTeamRole", "pms");

            // PK
            builder.HasKey(e => e.WorkTeamRoleID);

            // WorkTeamRoleID
            builder.Property(e => e.WorkTeamRoleID)
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
