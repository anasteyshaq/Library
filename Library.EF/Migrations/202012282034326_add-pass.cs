namespace Library.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addpass : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Reader", "Password", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Reader", "Password");
        }
    }
}
