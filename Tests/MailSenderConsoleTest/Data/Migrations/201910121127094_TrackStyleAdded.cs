namespace MailSenderConsoleTest.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TrackStyleAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Track", "Style", c => c.Byte());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Track", "Style");
        }
    }
}
