using Library.Core.Domain;
using Library.Core.Repisirories;
using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services
{
    public class BorrowingService : IBorrowingService
    {
        private readonly IBorrowingRepository _borrowingRepository;

        public BorrowingService(IBorrowingRepository bookRepository)
        {
            _borrowingRepository = bookRepository;
        }

        public async Task Add(BorrowingDTO borrowing)
        {
            try
            {
                await _borrowingRepository.AddAsync(new Borrowing()
                {
                    Id = borrowing.Id,
                    BorrowingDate = borrowing.BorrowingDate,
                    Deadline = borrowing.Deadline,
                    Returned = borrowing.Returned,
                    BookId = borrowing.BookId,
                    ReaderId = borrowing.ReaderId
                });
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _borrowingRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<BorrowingDTO> Get(int id)
        {
            var borrowing = await _borrowingRepository.GetAsync(id);
            return new BorrowingDTO()
            {
                Id = borrowing.Id,
                BorrowingDate = borrowing.BorrowingDate,
                Deadline = borrowing.Deadline,
                Returned = borrowing.Returned,
                BookId = borrowing.BookId,
                ReaderId = borrowing.ReaderId
            };
        }

        public async Task<IEnumerable<BorrowingDTO>> GetAll()
        {
            var borrowings = await _borrowingRepository.GetAllAsync();
            return borrowings.Select(b => new BorrowingDTO()
            {
                Id = b.Id,
                BorrowingDate = b.BorrowingDate,
                Deadline = b.Deadline,
                Returned = b.Returned,
                BookId = b.BookId,
                ReaderId = b.ReaderId
            });
        }

        public async Task<IEnumerable<BorrowingDTO>> GetByBook(int id)
        {
            var borrowings = await _borrowingRepository.GetByReaderAsync(id);
            return borrowings.Select(b => new BorrowingDTO()
            {
                Id = b.Id,
                BorrowingDate = b.BorrowingDate,
                Deadline = b.Deadline,
                Returned = b.Returned,
                BookId = b.BookId,
                ReaderId = b.ReaderId
            });
        }

        public async Task<IEnumerable<BorrowingDTO>> GetByReader(int id)
        {
            var borrowings = await _borrowingRepository.GetByReaderAsync(id);
            return borrowings.Select(b => new BorrowingDTO()
            {
                Id = b.Id,
                BorrowingDate = b.BorrowingDate,
                Deadline = b.Deadline,
                Returned = b.Returned,
                BookId = b.BookId,
                ReaderId = b.ReaderId
            });
        }

        public async Task<bool> isBookBorrowed(int id)
        {
            var borrowings = await _borrowingRepository.GetByReaderAsync(id);
            return borrowings.Where(x => x.Returned).Any();
        }

        public async Task Update(BorrowingDTO borrowing)
        {
            try
            {
                await _borrowingRepository.UpdateAsync(new Borrowing()
                {
                    Id = borrowing.Id,
                    BorrowingDate = borrowing.BorrowingDate,
                    Deadline = borrowing.Deadline,
                    Returned = borrowing.Returned,
                    BookId = borrowing.BookId,
                    ReaderId = borrowing.ReaderId
                });
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
