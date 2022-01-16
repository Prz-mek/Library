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
    public class LibrarianService : ILibrarianService
    {
        private readonly ILibrarianRepository _librarianRepository;

        public LibrarianService(ILibrarianRepository librarianRepository)
        {
            _librarianRepository = librarianRepository;
        }

        public async Task Add(LibrarianDTO librarian)
        {
            try
            {
                await _librarianRepository.AddAsync(new Librarian()
                {
                    Id = librarian.Id,
                    FirstName = librarian.FirstName,
                    LastName = librarian.LastName,
                    BranchLibraryId = librarian.BranchLibraryId,
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
                await _librarianRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<LibrarianDTO> Get(int id)
        {
            var librarian = await _librarianRepository.GetAsync(id);
            return new LibrarianDTO()
            {
                Id = librarian.Id,
                FirstName = librarian.FirstName,
                LastName = librarian.LastName,
                BranchLibraryId = librarian.BranchLibraryId,
            };
        }

        public async Task<IEnumerable<LibrarianDTO>> GetAll()
        {
            var librarians = await _librarianRepository.GetAllAsync();
            return librarians.Select(l => new LibrarianDTO()
            {
                Id = l.Id,
                FirstName = l.FirstName,
                LastName = l.LastName,
                BranchLibraryId = l.BranchLibraryId,
            });
        }

        public async Task Update(LibrarianDTO librarian)
        {
            try
            {
                await _librarianRepository.UpdateAsync(new Librarian()
                {
                    Id = librarian.Id,
                    FirstName = librarian.FirstName,
                    LastName = librarian.LastName,
                    BranchLibraryId = librarian.BranchLibraryId,
                });
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
