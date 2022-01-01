using Library.Infrastructure.DTO;
using Library.Infrastructure.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Library.WebAPI.Controllers
{
    [Route("[controller]")]
    public class ReaderController : Controller
    {
        private readonly IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var readers =  await _readerService.GetAll();
                return Json(readers);
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
                var reader = await _readerService.Get(id);
                return Json(reader);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] ReaderDTO reader)
        {
            try
            {
                await _readerService.Add(reader);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] ReaderDTO reader)
        {
            try
            {
                await _readerService.Update(reader);
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
                await _readerService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
