using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublisherData;
using PublisherDomain;

namespace PubAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly PubContext _context;
        private readonly DataLogic _dl;

        public AuthorsController(PubContext context)
        {
            _context = context;
        }

        public AuthorsController(DataLogic dl)
        {
            _dl = dl;
        }

        // GET: api/Authors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDTO>>> GetAuthors()
        {
            var authorDTOList = await _dl.GetAllAuthors();
            return authorDTOList;

            //return await _context.Authors
            //    .Select(a=>new AuthorDTO
            //    {
            //        AuthorId= a.AuthorId,
            //        FirstName= a.FirstName,
            //        LastName= a.LastName
            //    }).ToListAsync();
        }

        // GET: api/Authors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetAuthor(int id)
        {
            var authorDTO = await _dl.GetAuthorById(id);
            if (authorDTO == null)
            {
                return NotFound();
            }
            return authorDTO;

            //var author = await _context.Authors.FindAsync(id);

            //if (author == null)
            //{
            //    return NotFound();
            //}

            //return AuthorToDTO(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDTO>> PostAuthor(AuthorDTO authorDTO)
        {
            var author = AuthorFromDTO(authorDTO);
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, AuthorToDTO(author));
        }
        private static Author AuthorFromDTO(AuthorDTO authorDTO)
        {
            return new Author
            {
                AuthorId = authorDTO.AuthorId,
                FirstName = authorDTO.FirstName,
                LastName = authorDTO.LastName
            };
        }
        private static AuthorDTO AuthorToDTO(Author author)
        {
            return new AuthorDTO
            {
                AuthorId = author.AuthorId,
                FirstName = author.FirstName,
                LastName = author.LastName
            };
        }
        // PUT: api/Authors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAuthor(int id, AuthorDTO authorDTO)
        {
            if (id != authorDTO.AuthorId)
            {
                return BadRequest();
            }

            Author author = AuthorFromDTO(authorDTO);
            _context.Entry(author).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AuthorExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Authors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        //[HttpPost]
        //public async Task<ActionResult<Author>> PostAuthor(Author author)
        //{
        //    _context.Authors.Add(author);
        //    await _context.SaveChangesAsync();

        //    return CreatedAtAction("GetAuthor", new { id = author.AuthorId }, author);
        //}

        // DELETE: api/Authors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAuthor(int id)
        {
            //var author = await _context.Authors.FindAsync(id);
            //if (author == null)
            //{
            //    return NotFound();
            //}

            //_context.Authors.Remove(author);
            //await _context.SaveChangesAsync();

            var reccount = await _context.Database
                .ExecuteSqlInterpolatedAsync($"Delete from authors where authorid={id}");
            if (reccount == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        private bool AuthorExists(int id)
        {
            return _context.Authors.Any(e => e.AuthorId == id);
        }
    }
}
