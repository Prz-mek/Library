using Library.Core.Domain;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BorrowingRepository : IBorrowingRepository
    {
        private AppDbContext _appDbContext;

        public BorrowingRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Borrowing borrowing)
        {
            try
            {
                _appDbContext.Borrowing.Add(borrowing);
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
                _appDbContext.Remove(_appDbContext.Borrowing.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Borrowing>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.Borrowing);
        }

        public async Task<Borrowing> GetAsync(int id)
        {
            var borrowing = _appDbContext.Borrowing.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(borrowing);
        }

        public async Task<IEnumerable<Borrowing>> GetByBookAsync(int id)
        {
            var borrowings = _appDbContext.Borrowing.Where(x => x.BookId == id);
            return await Task.FromResult(borrowings);
        }

        public async Task<IEnumerable<Borrowing>> GetByReaderAsync(int id)
        {
            var borrowings = _appDbContext.Borrowing.Where(x => x.ReaderId == id);
            return await Task.FromResult(borrowings);
        }

        public async Task UpdateAsync(Borrowing borrowing)
        {
            try
            {
                var old = _appDbContext.Borrowing.FirstOrDefault(x => x.Id == borrowing.Id);
                old.Id = borrowing.Id;
                old.BorrowingDate = borrowing.BorrowingDate;
                old.Deadline = borrowing.Deadline;
                old.Returned = borrowing.Returned;

                old.BookId = borrowing.BookId;
                old.Book = borrowing.Book;

                old.ReaderId = borrowing.ReaderId;
                old.Reader = borrowing.Reader;                

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
