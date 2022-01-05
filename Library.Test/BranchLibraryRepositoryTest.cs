using Library.Core.Domain;
using Library.Core.Repisirories;
using Library.Infrastructure.DTO;
using Library.Infrastructure.Repositories;
using Library.Infrastructure.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Test
{
    [TestClass]
    public class BranchLibraryRepositoryTest
    {
        private readonly BranchLibraryService _branchLibraryService;
        private readonly Mock<IBranchLibraryRepository> _branchLibraryRepositoryMock = new Mock<IBranchLibraryRepository>();

        public BranchLibraryRepositoryTest()
        {
            _branchLibraryService = new BranchLibraryService(_branchLibraryRepositoryMock.Object);
        }

        [TestMethod]
        public async Task TestAdd()
        {
            // Arrange
            BranchLibraryDTO branchLibrary = new BranchLibraryDTO()
            {
                Id = 1
            };

            // Act
            await _branchLibraryService.Add(branchLibrary);

            // Assert
            _branchLibraryRepositoryMock.Verify(x => x.AddAsync(It.IsAny<BranchLibrary>()));
        }

        [TestMethod]
        public async Task TestUpdate()
        {
            // Arrange
            BranchLibraryDTO branchLibrary = new BranchLibraryDTO()
            {
                Id = 1,
                Name = "Bibl. nr 1"
            };

            // Act
            await _branchLibraryService.Update(branchLibrary);

            // Assert
            _branchLibraryRepositoryMock.Verify(x => x.UpdateAsync(It.IsAny<BranchLibrary>()));
        }

        [TestMethod]
        public async Task TestDelete()
        {
            // Arrange
            int id = 1;

            // Act
            await _branchLibraryService.Delete(id);

            // Assert
            _branchLibraryRepositoryMock.Verify(x => x.DeleteAsync(It.IsAny<int>()));
        }
    }
}
