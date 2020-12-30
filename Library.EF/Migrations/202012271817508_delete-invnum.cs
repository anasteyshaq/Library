namespace Library.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deleteinvnum : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Copy", "InventoryNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Copy", "InventoryNumber", c => c.Int(nullable: false));
        }
    }
}
