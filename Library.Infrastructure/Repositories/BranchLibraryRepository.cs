using Library.Core.Domain;
using Library.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class BranchLibraryRepository : IBranchLibraryRepository
    {
        private AppDbContext _appDbContext;

        public BranchLibraryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(BranchLibrary library)
        {
            try
            {
                _appDbContext.Add(library);
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
                _appDbContext.Remove(_appDbContext.BranchLibrary.FirstOrDefault(x => x.Id == id));
                _appDbContext.SaveChanges();
                await Task.CompletedTask;
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<IEnumerable<BranchLibrary>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.BranchLibrary);
        }

        public async Task<BranchLibrary> GetAsync(int id)
        {
            var library = _appDbContext.BranchLibrary.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(library);
        }

        public async Task UpdateAsync(BranchLibrary library)
        {
            try
            {
                var old = _appDbContext.BranchLibrary.FirstOrDefault(x => x.Id == library.Id);
                old.Id = library.Id;
                old.Name = library.Name;
                old.Street = library.Street;
                old.HauseNumber = library.HauseNumber;

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
