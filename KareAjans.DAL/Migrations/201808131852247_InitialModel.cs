namespace KareAjans.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AddressLine = c.String(maxLength: 300),
                        District = c.String(maxLength: 50),
                        City = c.String(maxLength: 50),
                        Country = c.String(maxLength: 50),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        PhoneNumber = c.String(maxLength: 24),
                        FaxNumber = c.String(maxLength: 24),
                        WebAddress = c.String(),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(maxLength: 24),
                        Email = c.String(nullable: false, maxLength: 150),
                        Internal = c.String(maxLength: 10),
                        CustomerId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Organizations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 250),
                        ModelsNeeded = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Type = c.String(maxLength: 50),
                        Expense = c.Decimal(precision: 18, scale: 2),
                        ContractPrice = c.Decimal(precision: 18, scale: 2),
                        Income = c.Decimal(precision: 18, scale: 2),
                        Branch = c.Int(nullable: false),
                        CustomerId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 150),
                        UserRole = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Birthdate = c.DateTime(storeType: "date"),
                        PhoneNumber1 = c.String(maxLength: 24),
                        PhoneNumber2 = c.String(maxLength: 24),
                        ProfilePhoto = c.String(),
                        ShoeSize = c.Int(),
                        BodySize = c.String(maxLength: 5),
                        Weight = c.Int(),
                        HairColor = c.String(maxLength: 50),
                        EyeColor = c.String(maxLength: 50),
                        TravelAvailability = c.Boolean(nullable: false),
                        DrivingLicence = c.Boolean(nullable: false),
                        Category = c.Int(nullable: false),
                        Note = c.String(),
                        IsWorking = c.Boolean(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.Expenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Payment = c.Decimal(precision: 18, scale: 2),
                        AccomadationExpense = c.Decimal(precision: 18, scale: 2),
                        FoodExpense = c.Decimal(precision: 18, scale: 2),
                        ModelId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.ForeignLanguages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Level = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Trainings",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        Name = c.String(nullable: false, maxLength: 250),
                        ModelsNeeded = c.Int(nullable: false),
                        StartDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        EndDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .ForeignKey("dbo.Organizations", t => t.Id)
                .Index(t => t.Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.UserPhotoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PhotoUrl = c.String(nullable: false, maxLength: 550),
                        ModelId = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false, maxLength: 50),
                        Password = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 150),
                        UserRole = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        Birthdate = c.DateTime(storeType: "date"),
                        PhoneNumber1 = c.String(maxLength: 24),
                        PhoneNumber2 = c.String(maxLength: 24),
                        Title = c.String(nullable: false, maxLength: 150),
                        Department = c.String(nullable: false, maxLength: 50),
                        Branch = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        CreatedDate = c.DateTime(nullable: false, precision: 7, storeType: "datetime2"),
                        Address_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Addresses", t => t.Address_Id)
                .Index(t => t.Address_Id);
            
            CreateTable(
                "dbo.ModelForeignLanguage",
                c => new
                    {
                        ModelId = c.Int(nullable: false),
                        ForeignLanguageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ModelId, t.ForeignLanguageId })
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.ForeignLanguages", t => t.ForeignLanguageId, cascadeDelete: true)
                .Index(t => t.ModelId)
                .Index(t => t.ForeignLanguageId);
            
            CreateTable(
                "dbo.ModelTraining",
                c => new
                    {
                        ModelId = c.Int(nullable: false),
                        TrainingId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ModelId, t.TrainingId })
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .ForeignKey("dbo.Trainings", t => t.TrainingId, cascadeDelete: true)
                .Index(t => t.ModelId)
                .Index(t => t.TrainingId);
            
            CreateTable(
                "dbo.OrganizationModel",
                c => new
                    {
                        OrganizationId = c.Int(nullable: false),
                        ModelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.OrganizationId, t.ModelId })
                .ForeignKey("dbo.Organizations", t => t.OrganizationId, cascadeDelete: true)
                .ForeignKey("dbo.Models", t => t.ModelId, cascadeDelete: true)
                .Index(t => t.OrganizationId)
                .Index(t => t.ModelId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Organizations", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Trainings", "Id", "dbo.Organizations");
            DropForeignKey("dbo.OrganizationModel", "ModelId", "dbo.Models");
            DropForeignKey("dbo.OrganizationModel", "OrganizationId", "dbo.Organizations");
            DropForeignKey("dbo.UserPhotoes", "ModelId", "dbo.Models");
            DropForeignKey("dbo.ModelTraining", "TrainingId", "dbo.Trainings");
            DropForeignKey("dbo.ModelTraining", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Trainings", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.ModelForeignLanguage", "ForeignLanguageId", "dbo.ForeignLanguages");
            DropForeignKey("dbo.ModelForeignLanguage", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Expenses", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Models", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Organizations", "Address_Id", "dbo.Addresses");
            DropForeignKey("dbo.Contacts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "Address_Id", "dbo.Addresses");
            DropIndex("dbo.OrganizationModel", new[] { "ModelId" });
            DropIndex("dbo.OrganizationModel", new[] { "OrganizationId" });
            DropIndex("dbo.ModelTraining", new[] { "TrainingId" });
            DropIndex("dbo.ModelTraining", new[] { "ModelId" });
            DropIndex("dbo.ModelForeignLanguage", new[] { "ForeignLanguageId" });
            DropIndex("dbo.ModelForeignLanguage", new[] { "ModelId" });
            DropIndex("dbo.Employees", new[] { "Address_Id" });
            DropIndex("dbo.UserPhotoes", new[] { "ModelId" });
            DropIndex("dbo.Trainings", new[] { "Address_Id" });
            DropIndex("dbo.Trainings", new[] { "Id" });
            DropIndex("dbo.Expenses", new[] { "ModelId" });
            DropIndex("dbo.Models", new[] { "Address_Id" });
            DropIndex("dbo.Organizations", new[] { "Address_Id" });
            DropIndex("dbo.Organizations", new[] { "CustomerId" });
            DropIndex("dbo.Contacts", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "Address_Id" });
            DropTable("dbo.OrganizationModel");
            DropTable("dbo.ModelTraining");
            DropTable("dbo.ModelForeignLanguage");
            DropTable("dbo.Employees");
            DropTable("dbo.UserPhotoes");
            DropTable("dbo.Trainings");
            DropTable("dbo.ForeignLanguages");
            DropTable("dbo.Expenses");
            DropTable("dbo.Models");
            DropTable("dbo.Organizations");
            DropTable("dbo.Contacts");
            DropTable("dbo.Customers");
            DropTable("dbo.Addresses");
        }
    }
}
