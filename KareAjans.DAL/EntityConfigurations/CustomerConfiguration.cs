using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            HasKey(c => c.Id);

            Property(c => c.Status)
                .IsRequired();

            Property(c => c.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(c => c.Name)
                .HasMaxLength(250)
                .IsRequired();

            Property(c => c.PhoneNumber)
                .HasMaxLength(24)
                .IsOptional();

            Property(c => c.FaxNumber)
                .HasMaxLength(24)
                .IsOptional();

            Property(c => c.WebAddress)
                .IsMaxLength()
                .IsOptional();

            HasOptional(c => c.Address)
                .WithOptionalDependent(a => a.Customer);

            HasMany(c => c.Contacts)
                .WithRequired(c => c.Customer)
                .HasForeignKey(c => c.CustomerId);

            HasMany(c => c.Organizations)
                .WithRequired(o => o.Customer)
                .HasForeignKey(o => o.CustomerId);
        }
    }
}
