namespace Library.WebApp.Models.Book
{
    public class BookEditVM
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string Author { get; set; }

        public int BranchLibraryId { get; set; }
    }
}
