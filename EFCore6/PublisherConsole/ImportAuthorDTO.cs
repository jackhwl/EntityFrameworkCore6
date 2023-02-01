using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublisherConsole
{
    public class ImportAuthorDTO
    {
        private readonly string _firstName;
        private readonly string _lastName;

        public ImportAuthorDTO(string firstName, string lastName)
        {
            _firstName = firstName;
            _lastName = lastName;
        }

        public string FirstName => _firstName;
        public string LastName => _lastName;
    }
}
