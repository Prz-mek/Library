using Library.Infrastructure.Commands;
using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("[controller]")]
    public class BorrowingController : Controller
    {
        private readonly IBorrowingService _borrowingService;
        private readonly IBookService _bookService;

        public BorrowingController(IBorrowingService borrowingService, IBookService bookService)
        {
            _borrowingService = borrowingService;
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var borrowings = await _borrowingService.GetAll();
                return Json(borrowings);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("shortened")]
        public async Task<IActionResult> GetAllShortened()
        {
            try
            {
                var borrowings = await _borrowingService.GetAll();
                return Json(borrowings.Select(async b => {
                    var book = await _bookService.Get(b.Id);
                    return new BorrowingShortened()
                    {
                        Id = b.Id,
                        Deadline = b.Deadline,
                        Returned = b.Returned,
                        BookTitle = book.Title
                    };
                }));
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
                var borrowing = await _borrowingService.Get(id);
                return Json(borrowing);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BorrowingDTO borrowing)
        {
            try
            {
                await _borrowingService.Add(borrowing);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BorrowingDTO borrowing)
        {
            try
            {
                borrowing.Id = id;
                await _borrowingService.Update(borrowing);
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
                await _borrowingService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
