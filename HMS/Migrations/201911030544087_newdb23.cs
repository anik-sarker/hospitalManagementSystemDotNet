namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newdb23 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.patientReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientsId = c.Int(nullable: false),
                        DoctorsId = c.Int(nullable: false),
                        cure = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.doctors", t => t.DoctorsId, cascadeDelete: true)
                .ForeignKey("dbo.patients", t => t.PatientsId, cascadeDelete: true)
                .Index(t => t.PatientsId)
                .Index(t => t.DoctorsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.patientReports", "PatientsId", "dbo.patients");
            DropForeignKey("dbo.patientReports", "DoctorsId", "dbo.doctors");
            DropIndex("dbo.patientReports", new[] { "DoctorsId" });
            DropIndex("dbo.patientReports", new[] { "PatientsId" });
            DropTable("dbo.patientReports");
        }
    }
}
