using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class Reader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public List<Borrowing> Borrowings { get; set; }
    }
}
