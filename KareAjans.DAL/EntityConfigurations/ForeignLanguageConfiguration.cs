using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class ForeignLanguageConfiguration : EntityTypeConfiguration<ForeignLanguage>
    {
        public ForeignLanguageConfiguration()
        {
            HasKey(fl => fl.Id);

            Property(fl => fl.Status)
                .IsRequired();

            Property(fl => fl.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(fl => fl.Name)
                .HasMaxLength(50)
                .IsRequired();

            Property(fl => fl.Level)
                .IsRequired();
        }
    }
}
