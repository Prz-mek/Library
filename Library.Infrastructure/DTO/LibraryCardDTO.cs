using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Infrastructure.DTO
{
    public class LibraryCardDTO
    {
        public int Id { get; set; }
        public int CardCode { get; set; }
        public DateTime DateOfIssue { get; set; }

        public int ReaderId { get; set; }
    }
}
