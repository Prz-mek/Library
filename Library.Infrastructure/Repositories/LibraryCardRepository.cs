using Library.Core.Domain;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class LibraryCardRepository : ILibraryCardRepository
    {
        private AppDbContext _appDbContext;

        public LibraryCardRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(LibraryCard libraryCard)
        {
            try
            {
                _appDbContext.LibraryCard.Add(libraryCard);
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
                _appDbContext.Remove(_appDbContext.LibraryCard.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<LibraryCard>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.LibraryCard);
        }

        public async Task<LibraryCard> GetAsync(int id)
        {
            var libraryCard = _appDbContext.LibraryCard.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(libraryCard);
        }

        public async Task<LibraryCard> GetByCodeAsync(int code)
        {
            var libraryCard = _appDbContext.LibraryCard.FirstOrDefault(x => x.CardCode == code);
            return await Task.FromResult(libraryCard);
        }

        public async Task UpdateAsync(LibraryCard libraryCard)
        {
            try
            {
                var old = _appDbContext.LibraryCard.FirstOrDefault(x => x.Id == libraryCard.Id);
                old.Id = libraryCard.Id;
                old.CardCode = libraryCard.CardCode;
                old.DateOfIssue = libraryCard.DateOfIssue;
                old.ReaderId = libraryCard.ReaderId;

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
