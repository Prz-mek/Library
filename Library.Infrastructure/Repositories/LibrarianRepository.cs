using Library.Core.Domain;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class LibrarianRepository : ILibrarianRepository
    {
        private AppDbContext _appDbContext;

        public LibrarianRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Librarian librarian)
        {
            try
            {
                _appDbContext.Librarian.Add(librarian);
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
                _appDbContext.Remove(_appDbContext.Librarian.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<Librarian>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.Librarian);
        }

        public async Task<Librarian> GetAsync(int id)
        {
            var librarian = _appDbContext.Librarian.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(librarian);
        }

        public async Task UpdateAsync(Librarian librarian)
        {
            try
            {
                var old = _appDbContext.Librarian.FirstOrDefault(x => x.Id == librarian.Id);
                old.Id = librarian.Id;
                old.FirstName = librarian.FirstName;
                old.LastName = librarian.LastName;
                old.UserName = librarian.UserName;

                old.BranchLibrary = librarian.BranchLibrary;

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
