using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface ILibrarianRepository
    {
        Task AddAsync(Librarian librarian);

        Task UpdateAsync(Librarian librarian);

        Task<Librarian> GetAsync(int id);

        Task<IEnumerable<Librarian>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
