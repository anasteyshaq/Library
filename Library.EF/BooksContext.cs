using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Library.Data;
using Library.Data.Entities;

namespace Library.EF
{
    public class BooksContext : DbContext
    {
        public BooksContext() : base("Library")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BooksContext,
                Library.EF.Migrations.Configuration>());
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Copy> Copies { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<Publication> Publications { get; set; }
        public DbSet<PublicationInStorage> PublicationsInStorage { get; set; }
        public DbSet<CopyInForm> CopiesinForms { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Storage> Storages { get; set; }

        /* отношение между моделями */
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Copy>()
                 .HasMany(p => p.CopiesInForm) // связь один ко многим между экземпярами и записями
                 .WithRequired(c => c.Copy) // обязательная установка свойства Copy у класса CopiesInForms
                 .WillCascadeOnDelete(false); // выключить каскадное удаление 

            modelBuilder.Entity<Storage>()
                 .HasMany(p => p.PublicationsInStorages) // связь один ко многим между экземпярами и записями
                 .WithRequired(c => c.Storage) // обязательная установка свойства Copy у класса CopiesInForms
                 .WillCascadeOnDelete(false); // выключить каскадное удаление 

            /* TPT Inheritance */
            modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Newspaper>().ToTable("Newspapers");
            modelBuilder.Entity<Magazine>().ToTable("Magazines");

            modelBuilder.Entity<Reader>();
            modelBuilder.Entity<PublicationInStorage>().HasKey(p => new { p.PublicationId, p.StorageId });
        }
    }
}
