using Library.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.ServiceInterfaces
{
    public interface ILibraryCardService
    {
        Task Add(LibraryCardDTO libraryCard);

        Task Update(LibraryCardDTO libraryCard);

        Task<LibraryCardDTO> Get(int id);

        Task<LibraryCardDTO> GetByCode(int code);

        Task<IEnumerable<LibraryCardDTO>> GetAll();

        Task Delete(int id);
    }
}
