using Library.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.ServiceInterfaces
{
    public interface IReaderService
    {
        Task Add(ReaderDTO reader);

        Task Update(ReaderDTO reader);

        Task<ReaderDTO> Get(int id);

        Task<IEnumerable<ReaderDTO>> GetAll();

        Task Delete(int id);
    }
}
