using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Speciality"/>
    /// </summary>
    public class SpecialityConfiguration : IEntityTypeConfiguration<Speciality>
    {
        /// <summary>
        /// Конфигурация таблицы Speciality
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<Speciality> builder)
        {
            // Table
            builder.ToTable("Speciality", "pms");

            // PK
            builder.HasKey(e => e.SpecialityID);

            // SpecialityID
            builder.Property(e => e.SpecialityID)
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
