using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repisirories
{
    public interface IBorrowingRepository
    {
        Task AddAsync(Borrowing borrowing);

        Task UpdateAsync(Borrowing borrowing);

        Task<Borrowing> GetAsync(int id);

        Task<IEnumerable<Borrowing>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
