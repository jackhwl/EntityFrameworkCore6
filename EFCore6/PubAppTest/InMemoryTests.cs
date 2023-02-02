using Microsoft.EntityFrameworkCore;
using PublisherConsole;
using PublisherData;
using PublisherDomain;

namespace PubAppTest
{
    [TestClass]
    public class InMemoryTests
    {
        [TestMethod]
        public void CanInsertAuthorIntoDatabase()
        {
            var builder = new DbContextOptionsBuilder<PubContext>();
            builder.UseInMemoryDatabase("CanInsertAuthorIntoDatabase"); //Guid.NewGuid().ToString()

            using (var context = new PubContext(builder.Options))
            {
                var author = new Author { FirstName = "a", LastName = "b" };
                context.Authors.Add(author);

                Assert.AreEqual(EntityState.Added, context.Entry(author).State);

            }
        }

        [TestMethod] 
        public void InsertAuthorsReturnsCorrectResultNumber()
        { 
            var builder = new DbContextOptionsBuilder<PubContext>();
            builder.UseInMemoryDatabase("InsertAuthorsReturnsCorrectResultNumber");
            var authorList = new List<ImportAuthorDTO>()
            {
                new ImportAuthorDTO("a", "b"),
                new ImportAuthorDTO("c", "d"),
                new ImportAuthorDTO("e", "f")
            };
            var dl = new DataLogic(new PubContext(builder.Options));
            var result = dl.ImportAuthors(authorList);
            Assert.AreEqual(authorList.Count, result);
        }

        [TestMethod]
        public void CanGetAnAuthorById()
        {
            //Arrange (set up builder & seed data)
            var builder = new DbContextOptionsBuilder<PubContext>();
            builder.UseInMemoryDatabase("CanGetAnAuthorById");
            int seededId = SeedOneAuthor(builder.Options);
            //Act (call the method)
            using (var context = new PubContext(builder.Options))
            {
                var bizlogic = new PubAPI.DataLogic(context);
                var authorRetrieved = bizlogic.GetAuthorById(seededId);
                //Assert (check the results)
                Assert.AreEqual(seededId, authorRetrieved.Result.AuthorId);
            }
        }

        private int SeedOneAuthor(DbContextOptions<PubContext> options)
        {
            using (var seedcontext = new PubContext(options))
            {
                var author = new Author { FirstName = "a", LastName= "b" };
                seedcontext.Authors.Add(author);
                seedcontext.SaveChanges();
                return author.AuthorId;
            }
        }
    }
}