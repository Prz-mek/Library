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
    public class ReaderService : IReaderService
    {
        private readonly IReaderRepository _readerRepository;

        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public async Task Add(ReaderDTO reader)
        {
            try
            {
                await _readerRepository.AddAsync(new Reader()
                {
                    Id = reader.Id,
                    FirstName = reader.FirstName,
                    LastName = reader.LastName,
                    Email = reader.Email,
                    DateOfBirth = reader.DateOfBirth
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
                await _readerRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }

        public async Task<ReaderDTO> Get(int id)
        {
            var reader = await _readerRepository.GetAsync(id);
            return await Task.FromResult(new ReaderDTO()
            {
                Id = reader.Id,
                FirstName = reader.FirstName,
                LastName = reader.LastName,
                Email = reader.Email,
                DateOfBirth = reader.DateOfBirth
            });
        }

        public async Task<IEnumerable<ReaderDTO>> GetAll()
        {
            var readers = await _readerRepository.GetAllAsync();
            return readers.Select(r => new ReaderDTO()
            {
                Id = r.Id,
                FirstName = r.FirstName,
                LastName = r.LastName,
                Email = r.Email,
                DateOfBirth = r.DateOfBirth
            });
        }

        public async Task Update(ReaderDTO reader)
        {
            try
            {
                await _readerRepository.UpdateAsync(new Reader()
                {
                    Id = reader.Id,
                    FirstName = reader.FirstName,
                    LastName = reader.LastName,
                    Email = reader.Email,
                    DateOfBirth = reader.DateOfBirth
                });
            }
            catch (Exception ex)
            {
                await Task.FromException(ex);
            }
        }
    }
}
