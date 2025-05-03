using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Department"/>
    /// </summary>
    public class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        /// <summary>
        /// Конфигурация таблицы Department
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            // Table
            builder.ToTable("Department", "pms");

            // PK
            builder.HasKey(e => e.DepartmentID);

            // DepartmentID
            builder.Property(e => e.DepartmentID)
                .UseIdentityColumn();

            // Code
            builder.Property(e => e.Code)
                .HasMaxLength(50);

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
