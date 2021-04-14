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
    public class ModelConfiguration : EntityTypeConfiguration<Model>
    {
        public ModelConfiguration()
        {
            Property(m => m.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity)
                .HasColumnOrder(0);

            Property(m => m.UserName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(1);

            Property(m => m.Password)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(2);

            Property(m => m.Email)
                .HasMaxLength(150)
                .IsRequired()
                .HasColumnOrder(3);

            Property(m => m.UserRole)
                .IsRequired()
                .HasColumnOrder(4);

            Property(m => m.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(5);

            Property(m => m.MiddleName)
                .HasMaxLength(50)
                .HasColumnOrder(6);

            Property(m => m.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .HasColumnOrder(7);

            Property(m => m.Gender)
                .IsRequired()
                .HasColumnOrder(8);

            Property(m => m.Birthdate)
                .HasColumnType("date")
                .IsOptional()
                .HasColumnOrder(9);

            Property(m => m.PhoneNumber1)
                .HasMaxLength(24)
                .IsOptional()
                .HasColumnOrder(10);

            Property(m => m.ShoeSize)
                .IsOptional();

            Property(m => m.BodySize)
                .HasMaxLength(5)
                .IsOptional();

            Property(m => m.Weight)
                .IsOptional();

            Property(m => m.Height)
                .IsOptional();

            Property(m => m.HairColor)
                .HasMaxLength(50)
                .IsOptional();

            Property(m => m.EyeColor)
                .HasMaxLength(50)
                .IsOptional();

            Property(m => m.Category)
                .IsRequired();

            Property(m => m.Note)
                .IsMaxLength()
                .IsOptional();

            Property(m => m.Status)
                .IsRequired();

            Property(m => m.CreatedDate)
                .HasColumnType("datetime2")
                .IsRequired();

            HasOptional(m => m.Address)
                .WithOptionalDependent(a => a.Model);

            HasMany(m => m.ForeignLanguages)
                .WithMany(fl => fl.Models)
                .Map(mfl =>
                {
                    mfl.MapLeftKey("ModelId");
                    mfl.MapRightKey("ForeignLanguageId");
                    mfl.ToTable("ModelForeignLanguage");
                });

            HasMany(m => m.UserPhotos)
                .WithRequired(up => up.Model)
                .HasForeignKey(up => up.ModelId);

            HasMany(m => m.Trainings)
                .WithMany(t => t.Models)
                .Map(t =>
                {
                    t.MapLeftKey("ModelId");
                    t.MapRightKey("TrainingId");
                    t.ToTable("ModelTraining");
                });

            HasMany(m => m.Expenses)
                .WithRequired(m => m.Model)
                .HasForeignKey(m => m.ModelId);

        }
    }
}
