using Library.Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.ServiceInterfaces
{
    public interface IBranchLibraryService
    {
        Task Add(BranchLibraryDTO branchLibrary);

        Task Update(BranchLibraryDTO branchLibrary);

        Task<BranchLibraryDTO> Get(int id);

        Task<IEnumerable<BranchLibraryDTO>> GetAll();

        Task Delete(int id);
    }
}
