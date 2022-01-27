using System;

namespace Library.WebApp.Models.Reader
{
    public class ReaderCreateVM
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string UserName { get; set; }
    }
}
