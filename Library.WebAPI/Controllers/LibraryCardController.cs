using Library.Infrastructure.Commands;
using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("[controller]")]
    public class LibraryCardController : Controller
    {
        private readonly ILibraryCardService _libraryCardService;

        public LibraryCardController(ILibraryCardService libraryCardService)
        {
            _libraryCardService = libraryCardService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var branchLibraries = await _libraryCardService.GetAll();
                return Json(branchLibraries);
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
                var branchLibrary = await _libraryCardService.Get(id);
                return Json(branchLibrary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("code/{code}")]
        public async Task<IActionResult> GetByCode(int code)
        {
            try
            {
                var branchLibrary = await _libraryCardService.GetByCode(code);
                return Json(branchLibrary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] LibraryCardCreate libraryCard)
        {
            try
            {
                await _libraryCardService.Add(new LibraryCardDTO()
                {
                    DateOfIssue = libraryCard.DateOfIssue,
                    ReaderId = libraryCard.ReaderId
                });
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
                await _libraryCardService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
