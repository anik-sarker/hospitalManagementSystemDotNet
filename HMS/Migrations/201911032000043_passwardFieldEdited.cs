namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwardFieldEdited : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.patients", "Password", c => c.String(nullable: false, maxLength: 18));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.patients", "Password", c => c.String(nullable: false));
        }
    }
}
