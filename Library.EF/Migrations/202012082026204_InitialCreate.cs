namespace Library.EF.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Publication",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Name = c.String(),
                    Publisher = c.String(),
                    NofPages = c.Int(),
                    PublicationDate = c.DateTime(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.Copy",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateInSystem = c.DateTime(nullable: false),
                    Publication_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publication", t => t.Publication_Id)
                .Index(t => t.Publication_Id);

            CreateTable(
                "dbo.CopyInForm",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    DateOfIssue = c.DateTime(nullable: false),
                    ReturnDate = c.DateTime(),
                    EstimatedReturnDate = c.DateTime(nullable: false),
                    ReaderId = c.Int(nullable: false),
                    CopyId = c.Int(nullable: false),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Reader", t => t.ReaderId)
                .ForeignKey("dbo.Copy", t => t.CopyId)
                .Index(t => t.ReaderId)
                .Index(t => t.CopyId);

            CreateTable(
                "dbo.Reader",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    TicketNumber = c.Int(nullable: false),
                    FirstName = c.String(),
                    LastName = c.String(),
                    PhoneNumber = c.String(),
                    Birthday = c.DateTime(nullable: false),
                    EMail = c.String(),
                })
                .PrimaryKey(t => t.Id);
      

            CreateTable(
                "dbo.Storage",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Sector = c.String(),
                    ShelfNumber = c.Int(nullable: false),
                    RowNumber = c.Int(nullable: false),
                    ColumnNumber = c.Int(nullable: false),
                    FloorNumber = c.Int(nullable: false),
                    WarehouseNumber = c.Int(nullable: false),
                    CellNumber = c.Int(nullable: false),
                    SetNumber = c.String(),
                })
                .PrimaryKey(t => t.Id);

            CreateTable(
                "dbo.PublicationStorage",
                c => new
                {
                    Publication_Id = c.Int(nullable: false),
                    Storage_Id = c.Int(nullable: false),
                })
                .PrimaryKey(t => new { t.Publication_Id, t.Storage_Id })
                .ForeignKey("dbo.Publication", t => t.Publication_Id, cascadeDelete: true)
                .ForeignKey("dbo.Storage", t => t.Storage_Id, cascadeDelete: true)
                .Index(t => t.Publication_Id)
                .Index(t => t.Storage_Id);

            CreateTable(
                "dbo.Books",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Genre = c.String(),
                    Series = c.String(),
                    Author = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publication", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Magazine",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Theme = c.String(),
                    Periodicity = c.String(),
                    Specialization = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publication", t => t.Id)
                .Index(t => t.Id);

            CreateTable(
                "dbo.Newspaper",
                c => new
                {
                    Id = c.Int(nullable: false),
                    Theme = c.String(),
                    Periodicity = c.String(),
                    AgeTo = c.Int(),
                    NewspaperFormat = c.String(),
                    Quality = c.String(),
                })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Publication", t => t.Id)
                .Index(t => t.Id);

        }

        public override void Down()
        {
            DropForeignKey("dbo.Newspaper", "Id", "dbo.Publication");
            DropForeignKey("dbo.Magazine", "Id", "dbo.Publication");
            DropForeignKey("dbo.Books", "Id", "dbo.Publication");
            DropForeignKey("dbo.PublicationStorage", "Storage_Id", "dbo.Storage");
            DropForeignKey("dbo.PublicationStorage", "Publication_Id", "dbo.Publication");
            DropForeignKey("dbo.Copy", "Publication_Id", "dbo.Publication");
            DropForeignKey("dbo.CopyInForm", "CopyId", "dbo.Copy");
            DropForeignKey("dbo.CopyInForm", "ReaderId", "dbo.Reader");
            DropIndex("dbo.Newspaper", new[] { "Id" });
            DropIndex("dbo.Magazine", new[] { "Id" });
            DropIndex("dbo.Books", new[] { "Id" });
            DropIndex("dbo.PublicationStorage", new[] { "Storage_Id" });
            DropIndex("dbo.PublicationStorage", new[] { "Publication_Id" });
            DropIndex("dbo.CopyInForm", new[] { "CopyId" });
            DropIndex("dbo.CopyInForm", new[] { "ReaderId" });
            DropIndex("dbo.Copy", new[] { "Publication_Id" });
            DropTable("dbo.Newspaper");
            DropTable("dbo.Magazine");
            DropTable("dbo.Books");
            DropTable("dbo.PublicationStorage");
            DropTable("dbo.Storage");
            DropTable("dbo.Reader");
            DropTable("dbo.CopyInForm");
            DropTable("dbo.Copy");
            DropTable("dbo.Publication");
        }
    }
}
