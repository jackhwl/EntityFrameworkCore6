using Microsoft.EntityFrameworkCore;
using PublisherConsole;
using PublisherData;
using PublisherDomain;

PubContext _context = new PubContext();
//using (PubContext context = new PubContext())
//{
//    context.Database.EnsureCreated();
//}

//GetAuthors();
//AddAuthor();
//GetAuthors();

//AddAuthorWithBook();
//GetAuthorsWithBooks();

//AddSomeMoreAuthors();
//SkipAndTakeAuthors();

//InsertNewAuthorWithNewBook();

//ConnectExistingArtistAndCoverObjects();
//CreateNewCoverWithExistingArtist();
//CreateNewCoverAndArtistTogether();

//RetrieveAnArtistWithTheirCovers();
//RetrieveACoverWithItsArtists();
//RetrieveAllArtistsWithTheirCovers();
//RetrieveAllArtistsWhoHaveCovers();

//RawSqlStoredProc();
//InterpolatedSqlStoredProc();
//GetAuthorsByArtist();
AddSomeAuthors();

void GetAuthorsByArtist()
{
    var authorartists = _context.AuthorsByArtist.ToList();
}
void RawSqlStoredProc()
{
    var authors = _context.Authors
        .FromSqlRaw("AuthorsPublishedinYearRange {0}, {1}", 2010, 2015)
        .ToList();
}


void InterpolatedSqlStoredProc()
{
    int start = 2010;
    int end = 2015;
    var authors = _context.Authors
    .FromSqlInterpolated($"AuthorsPublishedinYearRange {start}, {end}")
    .ToList();
}

void RetrieveAllArtistsWhoHaveCovers()
{
    var artistsWithCovers = _context.Artists.Where(a => a.Covers.Any()).ToList();
}

void RetrieveAllArtistsWithTheirCovers()
{
    var artistsWithCovers = _context.Artists.Include(a => a.Covers).ToList();
}

void RetrieveACoverWithItsArtists()
{
    var coverWithArtists = _context.Covers.Include(c => c.Artists)
                            .FirstOrDefault(c => c.CoverId == 1);
}
void RetrieveAnArtistWithTheirCovers()
{
    var artistWithCovers = _context.Artists.Include(a => a.Covers)
                            .FirstOrDefault(a => a.ArtistId == 1);
}

void CreateNewCoverAndArtistTogether()
{
    var newArtist = new Artist { FirstName = "Kir", LastName = "Talmage"};
    var newCover = new Cover { DesignIdeas = "We like birds!" };
    newArtist.Covers.Add(newCover);
    _context.Artists.Add(newArtist);
    _context.SaveChanges();
}

void CreateNewCoverWithExistingArtist()
{
    var artistA = _context.Artists.Find(1);
    var cover = new Cover { DesignIdeas = "Author has provided a photo"};
    cover.Artists.Add(artistA);
    _context.Covers.Add(cover);
    _context.SaveChanges();
}

void ConnectExistingArtistAndCoverObjects()
{
    var artistA = _context.Artists.Find(1);
    var artistB = _context.Artists.Find(2);
    var coverA = _context.Covers.Find(1);
    coverA.Artists.Add(artistA);
    coverA.Artists.Add(artistB);
    _context.SaveChanges();
}

void InsertNewAuthorWithNewBook()
{
    var author = new Author { FirstName = "Lynda", LastName = "Rutledge" };
    author.Books.Add(new Book
    {
        Title = "West With Giraffes",
        PublishDate = new DateTime(2021, 2, 1)
    });
    _context.Authors.Add(author);
    _context.SaveChanges();
}

void AddAuthorWithBook()
{
    var author = new Author { FirstName = "Julie", LastName = "Lerman" };
    author.Books.Add(new Book { Title = "Programming Entity Framework", PublishDate=new DateTime(2009,1,1) });
    author.Books.Add(new Book { Title = "Programming Entity Framework 2nd Ed", PublishDate = new DateTime(2010, 8, 1) });
    using var context = new PubContext();
    context.Authors.Add(author);
    context.SaveChanges();
}

void GetAuthorsWithBooks()
{
    using var context = new PubContext();
    var authors = context.Authors.Include(a => a.Books).ToList();
    foreach (var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
        foreach(var book in author.Books)
        {
            Console.WriteLine("*"+book.Title);
        }
    }
}

void AddAuthor()
{
    var author = new Author { FirstName = "Josie", LastName="Newf"};
    using var context = new PubContext();
    context.Authors.Add(author); 
    context.SaveChanges();
}

void AddSomeMoreAuthors()
{
    _context.Authors.Add(new Author { FirstName = "Rhoda", LastName = "Lerman"});
    _context.Authors.Add(new Author { FirstName = "Don", LastName = "Jones" });
    _context.Authors.Add(new Author { FirstName = "Jim", LastName = "Christopher" });
    _context.Authors.Add(new Author { FirstName = "Stephen", LastName = "Haunts" });
    _context.SaveChanges();
}

void AddSomeAuthors()
{
    var authorList = new List<ImportAuthorDTO>()
    {
        new ImportAuthorDTO("Ruth", "Ozeki"),
        new ImportAuthorDTO("Sofia", "Segovia"),
        new ImportAuthorDTO("Ursula K.", "LeGuin"),
        new ImportAuthorDTO("Hugh", "Howey"),
        new ImportAuthorDTO("Isabelle", "Allende"),
    };

    var dl = new DataLogic();
    dl.ImportAuthors(authorList);
}

void SkipAndTakeAuthors()
{
    var groupSize = 2;
    for(int i=0; i < 5; i++)
    {
        var authors = _context.Authors.Skip(groupSize * i).Take(groupSize).ToList();
        Console.WriteLine($"Group {i}:");
        foreach(var author in authors)
        {
            Console.WriteLine($" {author.FirstName} {author.LastName}");
        }
    }
}
void QueryAggregate()
{
    var author = _context.Authors.First(a => a.LastName == "Lerman");
}
void GetAuthors()
{
    using var context = new PubContext();
    var authors = context.Authors.ToList();
    foreach(var author in authors)
    {
        Console.WriteLine(author.FirstName + " " + author.LastName);
    }
}

