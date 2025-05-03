using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PMS.Model.Entities;

namespace PMS.Model.Configurations
{
    /// <summary>
    /// Конфигурация сущности <see cref="Employee"/>
    /// </summary>
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        /// <summary>
        /// Конфигурация таблицы Employee
        /// </summary>
        /// <param name="builder">Строитель сущности для конфигурации.</param>
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            // Table
            builder.ToTable("Employee", "pms");

            // PK
            builder.HasKey(e => e.EmployeeID);

            // EmployeeID
            builder.Property(e => e.EmployeeID)
                .UseIdentityColumn();

            // FirstName
            builder.Property(e => e.FirstName)
                .HasMaxLength(30)
                .IsRequired();

            //SecondName
            builder.Property(e => e.SecondName)
                .HasMaxLength(50)
                .IsRequired();

            // Surname
            builder.Property(e => e.Surname)
                .HasMaxLength(50);

            // Gender
            builder.Property(e => e.Gender)
                .IsRequired();

            // Birthdate
            builder.Property(e => e.Birthdate)
                .HasColumnType("date")
                .IsRequired();

            // SpecialityID (FK)
            builder.Property(e => e.SpecialityID)
                .IsRequired(false);

            builder
                .HasOne(e => e.Speciality)
                .WithMany(s => s.Employees)
                .HasForeignKey(e => e.SpecialityID);

            // DepartmentID (FK)
            builder.Property(e => e.DepartmentID)
                .IsRequired(false);

            builder
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentID);

            // UserID (FK)
            builder.Property(e => e.UserID)
                .IsRequired(false);

            builder
                .HasOne(e => e.User)
                .WithOne(u => u.Employee)
                .HasForeignKey<Employee>(e => e.UserID);

            builder.HasIndex(e => e.UserID)
                .IsUnique();
        }
    }
}
