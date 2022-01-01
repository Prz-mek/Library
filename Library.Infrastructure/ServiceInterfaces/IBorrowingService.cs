using Library.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.ServiceInterfaces
{
    public interface IBorrowingService
    {
        Task Add(BorrowingDTO borrowing);

        Task Update(BorrowingDTO borrowing);

        Task<BorrowingDTO> Get(int id);

        Task<IEnumerable<BorrowingDTO>> GetAll();

        Task Delete(int id);
    }
}
