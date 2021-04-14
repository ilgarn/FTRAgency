using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class ContactConfiguration : EntityTypeConfiguration<Contact>
    {
        public ContactConfiguration()
        {
            HasKey(m => m.Id);

            Property(m => m.Status)
                .IsRequired();

            Property(m => m.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();


            Property(m => m.FirstName)
                .HasMaxLength(50)
                .IsRequired();

            Property(m => m.MiddleName)
                .HasMaxLength(50);

            Property(m => m.LastName)
                .HasMaxLength(50)
                .IsRequired();

            Property(m => m.PhoneNumber)
                .HasMaxLength(24)
                .IsOptional();

            Property(m => m.Internal)
                .HasMaxLength(10)
                .IsOptional();

            Property(m => m.Email)
                .HasMaxLength(150)
                .IsRequired();


        }
    }
}
