namespace Hospital.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Diagnoses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Patients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Firstname = c.String(),
                        Lastname = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        dateOfBirth = c.DateTime(nullable: false),
                        Picture = c.Binary(),
                        MedicalInsurance = c.Boolean(nullable: false),
                        DiagnoseId = c.Int(nullable: false),
                        VisitationId = c.Int(nullable: false),
                        MedicamentId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Diagnoses", t => t.DiagnoseId, cascadeDelete: true)
                .ForeignKey("dbo.Medicaments", t => t.MedicamentId, cascadeDelete: true)
                .ForeignKey("dbo.Visitations", t => t.VisitationId, cascadeDelete: true)
                .Index(t => t.DiagnoseId)
                .Index(t => t.VisitationId)
                .Index(t => t.MedicamentId);
            
            CreateTable(
                "dbo.Medicaments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Visitations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Comment = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Patients", "VisitationId", "dbo.Visitations");
            DropForeignKey("dbo.Patients", "MedicamentId", "dbo.Medicaments");
            DropForeignKey("dbo.Patients", "DiagnoseId", "dbo.Diagnoses");
            DropIndex("dbo.Patients", new[] { "MedicamentId" });
            DropIndex("dbo.Patients", new[] { "VisitationId" });
            DropIndex("dbo.Patients", new[] { "DiagnoseId" });
            DropTable("dbo.Visitations");
            DropTable("dbo.Medicaments");
            DropTable("dbo.Patients");
            DropTable("dbo.Diagnoses");
        }
    }
}
