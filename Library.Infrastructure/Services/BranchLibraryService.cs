using Library.Core.Domain;
using Library.Core.Repisirories;
using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services
{
    public class BranchLibraryService : IBranchLibraryService
    {
        private readonly IBranchLibraryRepository _branchLibraryRepository;

        public BranchLibraryService(IBranchLibraryRepository branchLibraryRepository)
        {
            _branchLibraryRepository = branchLibraryRepository;
        }

        public async Task Add(BranchLibraryDTO branchLibrary)
        {
            try
            {
                await _branchLibraryRepository.AddAsync(new BranchLibrary()
                {
                    Id = branchLibrary.Id,
                    Name = branchLibrary.Name,
                    Street = branchLibrary.Street,
                    HauseNumber = branchLibrary.HauseNumber
                });
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _branchLibraryRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<BranchLibraryDTO> Get(int id)
        {
            var branchLibrary = await _branchLibraryRepository.GetAsync(id);
            return new BranchLibraryDTO()
            {
                Id = branchLibrary.Id,
                Name = branchLibrary.Name,
                Street = branchLibrary.Street,
                HauseNumber = branchLibrary.HauseNumber
            };
        }

        public async Task<IEnumerable<BranchLibraryDTO>> GetAll()
        {
            var branchLibraries = await _branchLibraryRepository.GetAllAsync();
            return branchLibraries.Select(b => new BranchLibraryDTO()
            {
                Id = b.Id,
                Name = b.Name,
                Street = b.Street,
                HauseNumber = b.HauseNumber
            });
        }

        public async Task Update(BranchLibraryDTO branchLibrary)
        {
            try
            {
                await _branchLibraryRepository.UpdateAsync(new BranchLibrary()
                {
                    Id = branchLibrary.Id,
                    Name = branchLibrary.Name,
                    Street = branchLibrary.Street,
                    HauseNumber = branchLibrary.HauseNumber
                });
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
