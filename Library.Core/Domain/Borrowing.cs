using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Core.Domain
{
    public class Borrowing
    {
        public int Id { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime Deadline { get; set; }
        public bool Returned { get; set; }

        public int BookId { get; set; }
        public Book Book { get; set; }

        public int ReaderId { get; set; }
        public Reader Reader { get; set; }
    }
}
