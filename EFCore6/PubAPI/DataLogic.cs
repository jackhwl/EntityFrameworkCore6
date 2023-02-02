using Microsoft.EntityFrameworkCore;
using PubAPI;
using PublisherData;
namespace PubAPI
{
    using PublisherDomain;

	public class DataLogic
	{
		PubContext _context;
		public DataLogic(PubContext context)
		{
			_context= context;
		}

		public async Task<List<AuthorDTO>> GetAllAuthors()
		{
			var authorList = await _context.Authors.ToListAsync();
			var authorDTOList = new List<AuthorDTO>();
			foreach (var author in authorList)
			{
				authorDTOList.Add(AuthorToDTO(author));
			}

			return authorDTOList;
		}

		public async Task<AuthorDTO> GetAuthorById(int id)
		{
			var author = await _context.Authors.FindAsync(id);
			if (author == null)
			{
				return null;
			}
			return AuthorToDTO(author);
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
	}
}