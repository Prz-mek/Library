using System;

namespace Library.WebApp.Models.Borrowing
{
    public class BorrowingVM
    {
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public bool Returned { get; set; }

        public int BookTitle { get; set; }
    }
}
