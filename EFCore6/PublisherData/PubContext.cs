using Microsoft.EntityFrameworkCore;
using PublisherDomain;

namespace PublisherData
{
    public class PubContext: DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Publisher6;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author { AuthorId= 1, FirstName="Rhoda", LastName = "Lerman" });
            var authorList = new Author[]
            {
                new Author { AuthorId = 2, FirstName="Ruth", LastName = "Ozeki"},
                new Author { AuthorId = 3, FirstName="Sofia", LastName = "Segovia"},
                new Author { AuthorId = 4, FirstName="Ursula K.", LastName = "LeGuin"},
                new Author { AuthorId = 5, FirstName="Hugh", LastName = "Howey"},
                new Author { AuthorId = 6, FirstName="Isabelle", LastName = "Allende"}
            };
            modelBuilder.Entity<Author>().HasData(authorList);

            var someBooks = new Book[]
            {
                new Book { AuthorId = 1,BookId = 1, Title="In God's Ear", PublishDate=new DateTime(1989,3,1)},
                new Book { AuthorId = 2,BookId = 2, Title="A Tale For the Time Being", PublishDate=new DateTime(2013,12,31)},
                new Book { AuthorId = 3,BookId = 3, Title="The Left Hand of Darkness", PublishDate=new DateTime(1989,3,1)}
            };
            modelBuilder.Entity<Book>().HasData(someBooks);
        }
    }
}