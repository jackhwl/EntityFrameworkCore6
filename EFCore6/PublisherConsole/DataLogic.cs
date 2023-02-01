using PublisherData;
using PublisherDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherConsole
{
    public class DataLogic
    {
        private readonly PubContext _context;

        public DataLogic(PubContext context)
        {
            _context = context;
        }
        public DataLogic()
        {
            _context = new PubContext();
        }

        public int ImportAuthors(List<ImportAuthorDTO> authorList)
        {
            foreach(var a in authorList)
            {
                _context.Authors.Add(new Author { FirstName = a.FirstName, LastName = a.LastName});
            }
            return _context.SaveChanges();
        }
    }
}
