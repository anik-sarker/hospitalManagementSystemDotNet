namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tinAppoinment : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.appoinmentModules", newName: "appointmentModules");
            AddColumn("dbo.appointmentModules", "AppointmentDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.appointmentModules", "AppoinmentDateTime");
        }
        
        public override void Down()
        {
            AddColumn("dbo.appointmentModules", "AppoinmentDateTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.appointmentModules", "AppointmentDateTime");
            RenameTable(name: "dbo.appointmentModules", newName: "appoinmentModules");
        }
    }
}
