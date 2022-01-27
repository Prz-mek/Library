namespace Library.WebApp.Models.Libarian
{
    public class LibrarianVM
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        public int BranchLibraryId { get; set; }
    }
}
