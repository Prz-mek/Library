using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("[controller]")]
    public class BranchLibraryController : Controller
    {
        private readonly IBranchLibraryService _branchLibraryService;

        public BranchLibraryController(IBranchLibraryService branchLibraryService)
        {
            _branchLibraryService = branchLibraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var branchLibraries = await _branchLibraryService.GetAll();
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
                var branchLibrary = await _branchLibraryService.Get(id);
                return Json(branchLibrary);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] BranchLibraryDTO branchLibrary)
        {
            try
            {
                await _branchLibraryService.Add(branchLibrary);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] BranchLibraryDTO branchLibrary)
        {
            try
            {
                branchLibrary.Id = id;
                await _branchLibraryService.Update(branchLibrary);
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
                await _branchLibraryService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
