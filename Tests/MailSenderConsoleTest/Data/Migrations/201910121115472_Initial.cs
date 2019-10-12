namespace MailSenderConsoleTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Artists",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Track",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Length = c.Int(nullable: false),
                        Artist_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Artists", t => t.Artist_Id)
                .Index(t => t.Artist_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Track", "Artist_Id", "dbo.Artists");
            DropIndex("dbo.Track", new[] { "Artist_Id" });
            DropTable("dbo.Track");
            DropTable("dbo.Artists");
        }
    }
}
