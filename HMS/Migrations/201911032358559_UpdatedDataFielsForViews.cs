namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedDataFielsForViews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.admins", "Email", c => c.String(nullable: false));
            AddColumn("dbo.doctors", "Email", c => c.String(nullable: false));
            AddColumn("dbo.nurses", "Email", c => c.String(nullable: false));
            AddColumn("dbo.staffs", "Email", c => c.String(nullable: false));
            AddColumn("dbo.userInfoes", "Email", c => c.String());
            AddColumn("dbo.userInfoes", "Password", c => c.String());
            AlterColumn("dbo.admins", "Password", c => c.String(nullable: false, maxLength: 18));
            AlterColumn("dbo.doctors", "Password", c => c.String(nullable: false, maxLength: 18));
            AlterColumn("dbo.nurses", "Password", c => c.String(nullable: false, maxLength: 18));
            AlterColumn("dbo.userInfoes", "Post", c => c.String());
            DropColumn("dbo.userInfoes", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.userInfoes", "userId", c => c.Int(nullable: false));
            AlterColumn("dbo.userInfoes", "Post", c => c.String(nullable: false));
            AlterColumn("dbo.nurses", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.doctors", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.admins", "Password", c => c.String(nullable: false));
            DropColumn("dbo.userInfoes", "Password");
            DropColumn("dbo.userInfoes", "Email");
            DropColumn("dbo.staffs", "Email");
            DropColumn("dbo.nurses", "Email");
            DropColumn("dbo.doctors", "Email");
            DropColumn("dbo.admins", "Email");
        }
    }
}
