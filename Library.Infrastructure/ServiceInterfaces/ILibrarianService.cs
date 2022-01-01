using Library.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.ServiceInterfaces
{
    public interface ILibrarianService
    {
        Task Add(LibrarianDTO librarian);

        Task Update(LibrarianDTO librarian);

        Task<LibrarianDTO> Get(int id);

        Task<IEnumerable<LibrarianDTO>> GetAll();

        Task Delete(int id);
    }
}
