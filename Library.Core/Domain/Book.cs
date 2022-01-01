using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Author { get; set; }

        public int BranchLibraryId { get; set; }
        public BranchLibrary BranchLibrary { get; set; }

        public List<Borrowing> Borrowings { get; set; }
    }
}
