using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repisirories
{
    public interface IBookRepository
    {
        Task AddAsync(Book book);

        Task UpdateAsync(Book book);

        Task<Book> GetAsync(int id);

        Task<IEnumerable<Book>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
