namespace Users.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateUserTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "FirstName", c => c.String(nullable: false));
            AddColumn("dbo.Users", "LastName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "LastName");
            DropColumn("dbo.Users", "FirstName");
        }
    }
}
