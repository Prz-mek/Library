using Library.Core.Domain;
using Library.Core.Repisirories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        private AppDbContext _appDbContext;

        public ReaderRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task AddAsync(Reader reader)
        {
            try
            {
                _appDbContext.Reader.Add(reader);
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

        public async Task<IEnumerable<Reader>> GetAllAsync()
        {
            return await Task.FromResult(_appDbContext.Reader);
        }

        public async Task<Reader> GetAsync(int id)
        {
            var reader = _appDbContext.Reader.FirstOrDefault(x => x.Id == id);
            return await Task.FromResult(reader); ;
        }

        public async Task UpdateAsync(Reader reader)
        {
            try
            {
                var old = _appDbContext.Reader.FirstOrDefault(x => x.Id == reader.Id);
                old.Id = reader.Id;
                old.FirstName = reader.FirstName;
                old.LastName = reader.LastName;
                old.Email = reader.Email;
                old.DateOfBirth = reader.DateOfBirth;

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
