namespace KareAjans.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHeightPropertytoModelTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Models", "Height", c => c.Int());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Models", "Height");
        }
    }
}
