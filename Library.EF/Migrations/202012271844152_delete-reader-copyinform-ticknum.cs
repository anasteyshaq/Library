namespace Library.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletereadercopyinformticknum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Reader", "CopyInFormId");
            DropColumn("dbo.Reader", "TicketNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Reader", "TicketNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Reader", "CopyInFormId", c => c.Int(nullable: false));
        }
    }
}
