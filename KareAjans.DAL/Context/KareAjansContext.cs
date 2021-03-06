// <auto-generated />

using KareAjans.DAL.Entities;
using KareAjans.DAL.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KareAjans.DAL.Context
{
    public class KareAjansContext : DbContext
    {
        public DbSet<Address> Addresses { get; set; }

        public DbSet<Contact> Contacts { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Expense> Expenses { get; set; }

        public DbSet<ForeignLanguage> ForeignLanguages { get; set; }

        public DbSet<Model> Models { get; set; }

        public DbSet<Organization> Organizations { get; set; }

        public DbSet<Training> Trainings { get; set; }

        public DbSet<UserPhoto> UserPhotos { get; set; }
        
        public KareAjansContext()
            : base("name=DefaultConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AddressConfiguration());
            modelBuilder.Configurations.Add(new ContactConfiguration());
            modelBuilder.Configurations.Add(new CustomerConfiguration());
            modelBuilder.Configurations.Add(new EmployeeConfiguration());
            modelBuilder.Configurations.Add(new ExpenseConfiguration());
            modelBuilder.Configurations.Add(new ForeignLanguageConfiguration());
            modelBuilder.Configurations.Add(new ModelConfiguration());
            modelBuilder.Configurations.Add(new OrganizationConfiguration());
            modelBuilder.Configurations.Add(new TrainingConfiguration());
            modelBuilder.Configurations.Add(new UserPhotoConfiguration());

            base.OnModelCreating(modelBuilder);

        }
    }
}
