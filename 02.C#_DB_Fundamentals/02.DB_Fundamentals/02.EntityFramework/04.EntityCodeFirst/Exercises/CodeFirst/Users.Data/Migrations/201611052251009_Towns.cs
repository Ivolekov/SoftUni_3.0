namespace Users.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Towns : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Towns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Country = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Users", "BornTown_Id", c => c.Int());
            AddColumn("dbo.Users", "LivingTown_Id", c => c.Int());
            CreateIndex("dbo.Users", "BornTown_Id");
            CreateIndex("dbo.Users", "LivingTown_Id");
            AddForeignKey("dbo.Users", "BornTown_Id", "dbo.Towns", "Id");
            AddForeignKey("dbo.Users", "LivingTown_Id", "dbo.Towns", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Users", "LivingTown_Id", "dbo.Towns");
            DropForeignKey("dbo.Users", "BornTown_Id", "dbo.Towns");
            DropIndex("dbo.Users", new[] { "LivingTown_Id" });
            DropIndex("dbo.Users", new[] { "BornTown_Id" });
            DropColumn("dbo.Users", "LivingTown_Id");
            DropColumn("dbo.Users", "BornTown_Id");
            DropTable("dbo.Towns");
        }
    }
}
