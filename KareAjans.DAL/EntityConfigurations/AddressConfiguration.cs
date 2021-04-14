using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class AddressConfiguration : EntityTypeConfiguration<Address>
    {
        public AddressConfiguration()       
        {
            HasKey(a => a.Id);

            Property(a => a.Status)
                .IsRequired();

            Property(a => a.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(a => a.AddressLine)
                .HasMaxLength(300);

            Property(a => a.District)
                .HasMaxLength(50);

            Property(a => a.City)
                .HasMaxLength(50);

            Property(a => a.Country)
                .HasMaxLength(50);
        }
    }
}
