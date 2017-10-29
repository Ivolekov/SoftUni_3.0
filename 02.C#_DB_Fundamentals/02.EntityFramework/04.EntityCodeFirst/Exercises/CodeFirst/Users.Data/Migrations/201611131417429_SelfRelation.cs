namespace Users.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SelfRelation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserFriends",
                c => new
                    {
                        FriendId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.FriendId, t.UserId })
                .ForeignKey("dbo.Users", t => t.FriendId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.FriendId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserFriends", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserFriends", "FriendId", "dbo.Users");
            DropIndex("dbo.UserFriends", new[] { "UserId" });
            DropIndex("dbo.UserFriends", new[] { "FriendId" });
            DropTable("dbo.UserFriends");
        }
    }
}
