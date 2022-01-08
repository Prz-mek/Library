using Library.Infrastructure.Commands;
using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("[controller]")]
    public class BookController : Controller
    {
        private readonly IBookService _bookService;
        private readonly IBranchLibraryService _branchLibraryService;
        private readonly IBorrowingService _borrowingService;

        public BookController(IBookService bookService, IBranchLibraryService branchLibraryService, IBorrowingService borrowingService)
        {
            _bookService = bookService;
            _branchLibraryService = branchLibraryService;
            _borrowingService = borrowingService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var books = await _bookService.GetAll();
                return Json(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var book = await _bookService.Get(id);
                return Json(book);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("details/{id}")]
        public async Task<IActionResult> GetDetails(int id)
        {
            try
            {
                var book = await _bookService.Get(id);
                var library = await _branchLibraryService.Get(book.BranchLibraryId);
                var isBorrowed = await _borrowingService.isBookBorrowed(id);
                return Json(new BookDetails()
                {
                    Id = id,
                    Title = book.Title,
                    Author = book.Author,
                    PageCount = book.PageCount,

                    IsBorrowed = isBorrowed,

                    BranchLibraryName = library.Name,
                    BranchLibraryAddress = $"{library.Street} {library.HauseNumber}"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BookDTO book)
        {
            try
            {
                await _bookService.Add(book);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BookDTO book)
        {
            try
            {
               book.Id = id;
                await _bookService.Update(book);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _bookService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
