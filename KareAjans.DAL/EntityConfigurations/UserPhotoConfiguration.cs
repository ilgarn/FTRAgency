using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class UserPhotoConfiguration : EntityTypeConfiguration<UserPhoto>
    {
        public UserPhotoConfiguration()
        {
            HasKey(up=> up.Id);

            Property(up=> up.Status)
                .IsRequired();

            Property(up=> up.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(up => up.PhotoUrl)
                .HasMaxLength(550)
                .IsRequired();


        }
    }
}
