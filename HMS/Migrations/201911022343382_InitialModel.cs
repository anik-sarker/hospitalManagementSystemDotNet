namespace HMS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.appoinmentModules",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientsId = c.Int(nullable: false),
                        DoctorsId = c.Int(nullable: false),
                        AppoinmentDateTime = c.DateTime(nullable: false),
                        Sickness = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.doctors", t => t.DoctorsId, cascadeDelete: true)
                .ForeignKey("dbo.patients", t => t.PatientsId, cascadeDelete: true)
                .Index(t => t.PatientsId)
                .Index(t => t.DoctorsId);
            
            CreateTable(
                "dbo.doctors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(),
                        JoinDateTime = c.String(),
                        Education = c.String(),
                        Specialty = c.String(),
                        Location = c.String(),
                        Available = c.Boolean(nullable: false),
                        RunningPatients = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        PhoneNumber = c.String(nullable: false, maxLength: 11),
                        Gender = c.String(),
                        Birthdate = c.DateTime(nullable: false),
                        Address = c.String(),
                        Sickness = c.String(nullable: false),
                        Allergies = c.String(),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.helpdesks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ReportTitle = c.String(nullable: false),
                        ReportMessage = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.labReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientsId = c.Int(nullable: false),
                        DoctorsId = c.Int(nullable: false),
                        Report = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.doctors", t => t.DoctorsId, cascadeDelete: true)
                .ForeignKey("dbo.patients", t => t.PatientsId, cascadeDelete: true)
                .Index(t => t.PatientsId)
                .Index(t => t.DoctorsId);
            
            CreateTable(
                "dbo.nurses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(),
                        Gender = c.String(),
                        JoinDateTime = c.String(),
                        Education = c.String(),
                        Specialty = c.String(),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.payments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientsId = c.Int(nullable: false),
                        DoctorsId = c.Int(nullable: false),
                        Amount = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.doctors", t => t.DoctorsId, cascadeDelete: true)
                .ForeignKey("dbo.patients", t => t.PatientsId, cascadeDelete: true)
                .Index(t => t.PatientsId)
                .Index(t => t.DoctorsId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.staffs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        Address = c.String(),
                        JoinDateTime = c.String(),
                        Education = c.String(),
                        Post = c.String(),
                        Password = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.userInfoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        userId = c.Int(nullable: false),
                        Post = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.wards",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PatientsId = c.Int(nullable: false),
                        DoctorsId = c.Int(nullable: false),
                        NurseId = c.Int(nullable: false),
                        BedId = c.Byte(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.doctors", t => t.DoctorsId, cascadeDelete: true)
                .ForeignKey("dbo.nurses", t => t.NurseId, cascadeDelete: true)
                .ForeignKey("dbo.patients", t => t.PatientsId, cascadeDelete: true)
                .Index(t => t.PatientsId)
                .Index(t => t.DoctorsId)
                .Index(t => t.NurseId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.wards", "PatientsId", "dbo.patients");
            DropForeignKey("dbo.wards", "NurseId", "dbo.nurses");
            DropForeignKey("dbo.wards", "DoctorsId", "dbo.doctors");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.payments", "PatientsId", "dbo.patients");
            DropForeignKey("dbo.payments", "DoctorsId", "dbo.doctors");
            DropForeignKey("dbo.labReports", "PatientsId", "dbo.patients");
            DropForeignKey("dbo.labReports", "DoctorsId", "dbo.doctors");
            DropForeignKey("dbo.appoinmentModules", "PatientsId", "dbo.patients");
            DropForeignKey("dbo.appoinmentModules", "DoctorsId", "dbo.doctors");
            DropIndex("dbo.wards", new[] { "NurseId" });
            DropIndex("dbo.wards", new[] { "DoctorsId" });
            DropIndex("dbo.wards", new[] { "PatientsId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.payments", new[] { "DoctorsId" });
            DropIndex("dbo.payments", new[] { "PatientsId" });
            DropIndex("dbo.labReports", new[] { "DoctorsId" });
            DropIndex("dbo.labReports", new[] { "PatientsId" });
            DropIndex("dbo.appoinmentModules", new[] { "DoctorsId" });
            DropIndex("dbo.appoinmentModules", new[] { "PatientsId" });
            DropTable("dbo.wards");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.userInfoes");
            DropTable("dbo.staffs");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.payments");
            DropTable("dbo.nurses");
            DropTable("dbo.labReports");
            DropTable("dbo.helpdesks");
            DropTable("dbo.patients");
            DropTable("dbo.doctors");
            DropTable("dbo.appoinmentModules");
            DropTable("dbo.admins");
        }
    }
}
