namespace KareAjans.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePhoneNumber2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Models", "PhoneNumber2");
            DropColumn("dbo.Employees", "PhoneNumber2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "PhoneNumber2", c => c.String(maxLength: 24));
            AddColumn("dbo.Models", "PhoneNumber2", c => c.String(maxLength: 24));
        }
    }
}
