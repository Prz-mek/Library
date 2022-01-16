using Library.Core.Domain;
using Library.Core.Repositories;
using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Services
{
    public class LibraryCardService : ILibraryCardService
    {
        private readonly ILibraryCardRepository _libraryCardRepository;

        public LibraryCardService(ILibraryCardRepository libraryCardRepository)
        {
            _libraryCardRepository = libraryCardRepository;
        }

        public async Task Add(LibraryCardDTO libraryCard)
        {
            try
            {
                string hashInputString = libraryCard.DateOfIssue.ToString() + libraryCard.ReaderId.ToString();
                int code = Math.Abs(hashInputString.GetHashCode());
                await _libraryCardRepository.AddAsync(new LibraryCard()
                {
                    CardCode = code,
                    DateOfIssue = libraryCard.DateOfIssue,
                    ReaderId = libraryCard.ReaderId
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
                await _libraryCardRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<LibraryCardDTO> Get(int id)
        {
            var libraryCard = await _libraryCardRepository.GetAsync(id);
            return new LibraryCardDTO()
            {
                Id = libraryCard.Id,
                CardCode = libraryCard.CardCode,
                DateOfIssue = libraryCard.DateOfIssue,
                ReaderId = libraryCard.ReaderId
            };
        }

        public async Task<LibraryCardDTO> GetByCode(int code)
        {
            var libraryCard = await _libraryCardRepository.GetByCodeAsync(code);
            return new LibraryCardDTO()
            {
                Id = libraryCard.Id,
                CardCode = libraryCard.CardCode,
                DateOfIssue = libraryCard.DateOfIssue,
                ReaderId = libraryCard.ReaderId
            };
        }

        public async Task<IEnumerable<LibraryCardDTO>> GetAll()
        {
            var branchLibraries = await _libraryCardRepository.GetAllAsync();
            return branchLibraries.Select(l => new LibraryCardDTO()
            {
                Id = l.Id,
                CardCode = l.CardCode,
                DateOfIssue = l.DateOfIssue,
                ReaderId = l.ReaderId
            });
        }

        public async Task Update(LibraryCardDTO libraryCard)
        {
            try
            {
                await _libraryCardRepository.UpdateAsync(new LibraryCard()
                {
                    Id = libraryCard.Id,
                    CardCode = libraryCard.CardCode,
                    DateOfIssue = libraryCard.DateOfIssue,
                    ReaderId = libraryCard.ReaderId
                });
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
