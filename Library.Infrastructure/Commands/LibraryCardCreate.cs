using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.Commands
{
    public class LibraryCardCreate
    {
        public DateTime DateOfIssue { get; set; }
        public int ReaderId { get; set; }
    }
}
