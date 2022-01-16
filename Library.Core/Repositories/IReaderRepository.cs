using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IReaderRepository
    {
        Task AddAsync(Reader reader);

        Task UpdateAsync(Reader reader);

        Task<Reader> GetAsync(int id);

        Task<IEnumerable<Reader>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
