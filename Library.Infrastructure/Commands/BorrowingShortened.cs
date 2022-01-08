using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Commands
{
    public class BorrowingShortened
    {
        public int Id { get; set; }
        public DateTime Deadline { get; set; }
        public bool Returned { get; set; }

        public string BookTitle { get; set; }
    }
}
