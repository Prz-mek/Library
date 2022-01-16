using Library.Core.Domain;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IBranchLibraryRepository
    {
        Task AddAsync(BranchLibrary library);

        Task UpdateAsync(BranchLibrary library);

        Task<BranchLibrary> GetAsync(int id);

        Task<IEnumerable<BranchLibrary>> GetAllAsync();

        Task DeleteAsync(int id);
    }
}
