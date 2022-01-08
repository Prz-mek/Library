using System;

namespace Library.WebApp.Models.Borrowing
{
    public class BorrowingCreateVM
    {
        public DateTime BorrowingDate { get; set; }
        public DateTime Deadline { get; set; }
        public bool Returned { get; set; }

        public int BookId { get; set; }

        public int ReaderId { get; set; }
    }
}
