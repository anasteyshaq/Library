namespace Library.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class LibraryDBv1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Magazine", newName: "Magazines");
            RenameTable(name: "dbo.Newspaper", newName: "Newspapers");
            DropForeignKey("dbo.CopyInForm", "ReaderId", "dbo.Reader");
            DropForeignKey("dbo.Copy", "Publication_Id", "dbo.Publication");
            DropForeignKey("dbo.PublicationStorage", "Publication_Id", "dbo.Publication");
            DropForeignKey("dbo.PublicationStorage", "Storage_Id", "dbo.Storage");
            DropIndex("dbo.Copy", new[] { "Publication_Id" });
            DropIndex("dbo.CopyInForm", new[] { "ReaderId" });
            DropIndex("dbo.PublicationStorage", new[] { "Publication_Id" });
            DropIndex("dbo.PublicationStorage", new[] { "Storage_Id" });
            CreateTable(
                "dbo.PublicationInStorage",
                c => new
                    {
                        PublicationId = c.Int(nullable: false),
                        StorageId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PublicationId, t.StorageId })
                .ForeignKey("dbo.Storage", t => t.StorageId)
                .Index(t => t.StorageId);
            
            AddColumn("dbo.Copy", "PublicationId", c => c.Int(nullable: false));
            AddColumn("dbo.Copy", "InventoryNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Reader", "CopyInFormId", c => c.Int(nullable: false));
            DropColumn("dbo.Copy", "Publication_Id");
            DropTable("dbo.PublicationStorage");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.PublicationStorage",
                c => new
                    {
                        Publication_Id = c.Int(nullable: false),
                        Storage_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Publication_Id, t.Storage_Id });
            
            AddColumn("dbo.Copy", "Publication_Id", c => c.Int(nullable: false));
            DropForeignKey("dbo.PublicationInStorage", "StorageId", "dbo.Storage");
            DropIndex("dbo.PublicationInStorage", new[] { "StorageId" });
            DropColumn("dbo.Reader", "CopyInFormId");
            DropColumn("dbo.Copy", "InventoryNumber");
            DropColumn("dbo.Copy", "PublicationId");
            DropTable("dbo.PublicationInStorage");
            CreateIndex("dbo.PublicationStorage", "Storage_Id");
            CreateIndex("dbo.PublicationStorage", "Publication_Id");
            CreateIndex("dbo.CopyInForm", "ReaderId");
            CreateIndex("dbo.Copy", "Publication_Id");
            AddForeignKey("dbo.PublicationStorage", "Storage_Id", "dbo.Storage", "Id", cascadeDelete: true);
            AddForeignKey("dbo.PublicationStorage", "Publication_Id", "dbo.Publication", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Copy", "Publication_Id", "dbo.Publication", "Id");
            AddForeignKey("dbo.CopyInForm", "ReaderId", "dbo.Reader", "Id");
            RenameTable(name: "dbo.Newspapers", newName: "Newspaper");
            RenameTable(name: "dbo.Magazines", newName: "Magazine");
        }
    }
}
