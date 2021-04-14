using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class TrainingConfiguration : EntityTypeConfiguration<Training>
    {
        public TrainingConfiguration()
        {
            HasKey(t => t.Id);

            Property(t => t.Status)
                .IsRequired();

            Property(t => t.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(t => t.Name)
                .HasMaxLength(250)
                .IsRequired();

            Property(t => t.ModelsNeeded)
                .IsRequired();

            Property(t => t.StartDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(t => t.EndDate)
                .HasColumnType("datetime2")
                .IsRequired();

            HasOptional(t => t.Address)
                .WithOptionalDependent(a => a.Training);

        }
    }
}
