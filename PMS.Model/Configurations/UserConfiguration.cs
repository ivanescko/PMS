using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="User"/>
    /// </summary>
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Конфигурация таблицы User
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            // Table
            builder.ToTable("User", "pms");

            // PK
            builder.HasKey(e => e.UserID);

            // UserID
            builder.Property(e => e.UserID)
                .UseIdentityColumn();

            //Login
            builder.Property(e => e.Login)                
                .HasMaxLength(50)
                .IsRequired();

            // Password
            builder.Property(e => e.Password)                
                .HasMaxLength(50)
                .IsRequired();

            // Name
            builder.Property(e => e.Name)                
                .HasMaxLength(50)
                .IsRequired();

            // LastLoginDate
            builder.Property(e => e.LastLoginDate)
                .HasColumnType("timestamp without time zone");

            // IsActive
            builder.Property(e => e.IsActive)
                .HasDefaultValue(true)
                .IsRequired();
        }
    }
}
