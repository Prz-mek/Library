using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class LibraryCard
    {
        public int Id { get; set; }
        public int CardCode { get; set; }
        public DateTime DateOfIssue { get; set; }

        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
