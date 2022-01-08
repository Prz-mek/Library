namespace Library.WebApp.Models.Book
{
    public class BookDetailsVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int PageCount { get; set; }

        public bool IsBorrowed { get; set; }

        public string BranchLibraryName { get; set; }
        public string BranchLibraryAddress { get; set; }
    }
}
