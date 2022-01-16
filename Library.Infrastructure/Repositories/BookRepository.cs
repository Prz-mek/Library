using Library.Core.Domain;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private AppDbContext _appDbContext;

        public BookRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Book book)
        {
            try
            {
                _appDbContext.Book.Add(book);
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                _appDbContext.Remove(_appDbContext.Book.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.Book);
        }

        public async Task<Book> GetAsync(int id)
        {
            var book = _appDbContext.Book.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(book);
        }

        public async Task UpdateAsync(Book book)
        {
            try
            {
                var old = _appDbContext.Book.FirstOrDefault(x => x.Id == book.Id);
                old.Id = book.Id;
                old.Title = book.Title;
                old.PageCount = book.PageCount;
                old.Author = book.Author;
                
                old.BranchLibraryId = book.BranchLibraryId;
                old.BranchLibrary = book.BranchLibrary;

                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
