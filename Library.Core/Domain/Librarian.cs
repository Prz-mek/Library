using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class Librarian
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int BranchLibraryId { get; set; }
        public BranchLibrary BranchLibrary { get; set; }
    }
}
