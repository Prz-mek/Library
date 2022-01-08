using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Commands
{
    public class BookDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        public bool IsBorrowed { get; set; }

        public string BranchLibraryName { get; set; }
        public string BranchLibraryAddress { get; set; }
    }
}
