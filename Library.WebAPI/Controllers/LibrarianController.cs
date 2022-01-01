using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("[controller]")]
    public class LibrarianController : Controller
    {
        private readonly ILibrarianService _librarianService;

        public LibrarianController(ILibrarianService librarianService)
        {
            _librarianService = librarianService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var librarians = await _librarianService.GetAll();
                return Json(librarians);
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
                var librarian = await _librarianService.Get(id);
                return Json(librarian);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LibrarianDTO librarian)
        {
            try
            {
                await _librarianService.Add(librarian);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] LibrarianDTO librarian)
        {
            try
            {
                await _librarianService.Update(librarian);
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
                await _librarianService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
