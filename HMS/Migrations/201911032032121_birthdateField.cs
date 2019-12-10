namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class birthdateField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.patients", "DateOfBirth", c => c.DateTime());
            DropColumn("dbo.patients", "Birthdate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.patients", "Birthdate", c => c.DateTime(nullable: false));
            DropColumn("dbo.patients", "DateOfBirth");
        }
    }
}
