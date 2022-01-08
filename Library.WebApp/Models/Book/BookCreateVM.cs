namespace Library.WebApp.Models.Book
{
    public class BookCreateVM
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Author { get; set; }

        public int BranchLibraryId { get; set; }
    }
}
