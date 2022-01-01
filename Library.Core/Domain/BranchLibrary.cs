using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class BranchLibrary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Street { get; set; }
        public string HauseNumber { get; set; }

        public List<Book> Books { get; set; }
    }
}
