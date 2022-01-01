using Library.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.ServiceInterfaces
{
    public interface IBookService
    {
        Task Add(BookDTO book);

        Task Update(BookDTO book);

        Task<BookDTO> Get(int id);

        Task<IEnumerable<BookDTO>> GetAll();

        Task Delete(int id);
    }
}
