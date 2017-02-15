namespace SismaV02.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Birthdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "BirthDate", c => c.DateTime(nullable: false));
            DropColumn("dbo.AspNetUsers", "NameIdentifier");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "NameIdentifier", c => c.String());
            DropColumn("dbo.AspNetUsers", "BirthDate");
        }
    }
}
