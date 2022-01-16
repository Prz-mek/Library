using Library.Core.Domain;
using Library.Core.Repositories;
using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IBranchLibraryRepository _branchLibraryRepository;

        public BookService(IBookRepository bookRepository, IBranchLibraryRepository branchLibraryRepository)
        {
            _bookRepository = bookRepository;
            _branchLibraryRepository = branchLibraryRepository;
        }

        public async Task Add(BookDTO book)
        {
            try
            {
                var library = await _branchLibraryRepository.GetAsync(book.BranchLibraryId);
                Book newBook = new Book()
                {
                    Id = book.Id,
                    Title = book.Title,
                    PageCount = book.PageCount,
                    Author = book.Author,
                    BranchLibraryId = book.BranchLibraryId,
                };
                await _bookRepository.AddAsync(newBook);
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
                await _bookRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<BookDTO> Get(int id)
        {
            var book = await _bookRepository.GetAsync(id);
            return new BookDTO()
            {
                Id = book.Id,
                Title = book.Title,
                PageCount = book.PageCount,
                Author = book.Author,
                BranchLibraryId = book.BranchLibraryId,
            };
        }

        public async Task<IEnumerable<BookDTO>> GetAll()
        {
            var books = await _bookRepository.GetAllAsync();
            return books.Select(b => new BookDTO()
            {
                Id = b.Id,
                Title = b.Title,
                PageCount = b.PageCount,
                Author = b.Author,
                BranchLibraryId = b.BranchLibraryId,
            });
        }

        public async Task Update(BookDTO book)
        {
            try
            {
                await _bookRepository.UpdateAsync(new Book()
                {
                    Id = book.Id,
                    Title = book.Title,
                    PageCount = book.PageCount,
                    Author = book.Author,
                    BranchLibraryId = book.BranchLibraryId,
                });
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
