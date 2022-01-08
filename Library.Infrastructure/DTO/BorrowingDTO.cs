using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.DTO
{
    public class BorrowingDTO
    {
        public int Id { get; set; }
        public DateTime BorrowingDate { get; set; }
        public DateTime Deadline { get; set; }
        public bool Returned { get; set; }

        public int BookId { get; set; }

        public int ReaderId { get; set; }
    }
}
