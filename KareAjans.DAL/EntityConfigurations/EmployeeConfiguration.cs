using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class EmployeeConfiguration : EntityTypeConfiguration<Employee>
    {
        public EmployeeConfiguration()
        {
            Property(e => e.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0);

            Property(e => e.UserName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(1);

            Property(e => e.Password)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(2);

            Property(e => e.Email)
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnOrder(3);

            Property(e => e.UserRole)
                .IsRequired()
                .HasColumnOrder(4);

            Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(5);

            Property(e => e.MiddleName)
                .HasMaxLength(50)
                .HasColumnOrder(6);

            Property(e => e.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(7);

            Property(e => e.Birthdate)
                .HasColumnType("date")
                .IsOptional()
                .HasColumnOrder(8);

            Property(e => e.PhoneNumber1)
                .HasMaxLength(24)
                .IsOptional()
                .HasColumnOrder(9);

            Property(e => e.Title)
                .HasMaxLength(150)
                .IsRequired();

            Property(e => e.Department)
                .HasMaxLength(50)
                .IsRequired();

            Property(e => e.Branch)
                .IsRequired();

            Property(e => e.Status)
                .IsRequired();

            Property(e => e.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            HasOptional(e => e.Address)
                .WithOptionalDependent(a => a.Employee);



        }
    }
}
