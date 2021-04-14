using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class OrganizationConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationConfiguration()
        {
            HasKey(o => o.Id);

            Property(o => o.Status)
                .IsRequired();

            Property(o => o.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(o => o.Name)
                .HasMaxLength(250)
                .IsRequired();

            Property(o => o.ModelsNeeded)
                .IsRequired();

            Property(o => o.StartDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(o => o.EndDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(o => o.Type)
                .HasMaxLength(50)
                .IsOptional();

            Property(o => o.Expense)
                .IsOptional();

            Property(o => o.ContractPrice)
                .IsOptional();

            Property(o => o.Income)
                .IsOptional();

            Property(o => o.Branch)
                .IsRequired();

            HasOptional(o => o.Address)
                .WithOptionalDependent(a => a.Organization);

            HasOptional(o => o.Training)
                .WithRequired(t => t.Organization);

            HasMany(o => o.Models)
                .WithMany(m => m.Organizations)
                .Map(m =>
                {
                    m.MapLeftKey("OrganizationId");
                    m.MapRightKey("ModelId");
                    m.ToTable("OrganizationModel");
                });
        }
    }
}
