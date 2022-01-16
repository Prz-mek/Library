using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface ILibraryCardRepository
    {
        Task AddAsync(LibraryCard libraryCard);

        Task UpdateAsync(LibraryCard libraryCard);

        Task<LibraryCard> GetAsync(int id);

        Task<LibraryCard> GetByCodeAsync(int code);

        Task<IEnumerable<LibraryCard>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
