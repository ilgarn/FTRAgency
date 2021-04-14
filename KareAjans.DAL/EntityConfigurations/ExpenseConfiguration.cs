using KareAjans.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.EntityConfigurations
{
    public class ExpenseConfiguration : EntityTypeConfiguration<Expense>
    {
        public ExpenseConfiguration()
        {
            HasKey(e => e.Id);

            Property(e => e.Status)
                .IsRequired();

            Property(e => e.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            Property(e => e.Payment)
                .IsOptional();

            Property(e => e.AccomadationExpense)
                .IsOptional();

            Property(e => e.FoodExpense)
                .IsOptional();
        }
    }
}
