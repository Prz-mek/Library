using Library.WebApp.Models.Libarian;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Library.WebApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class LibrarianController : Controller
    {
        public IConfiguration Configuration;

        public LibrarianController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public ContentResult GetHostUrl()
        {
            var result = Configuration["RestApiUrl:hostUrl"];
            return Content(result);
        }

        private string GetControllerName()
        {
            string controllerName = ControllerContext.RouteData.Values["controller"].ToString();
            return controllerName;
        }


        public async Task<IActionResult> Index()
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            List<LibrarianVM> librarianList = new List<LibrarianVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    librarianList = JsonConvert.DeserializeObject<List<LibrarianVM>>(apiResponse);
                }
            }

            return View(librarianList);
        }

        public IActionResult Create()
        {
            LibrarianCreateVM librarian = new LibrarianCreateVM();
            return View(librarian);
        }

        [HttpPost]
        public async Task<IActionResult> Create(LibrarianCreateVM librarian)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string librarianJson = System.Text.Json.JsonSerializer.Serialize(librarian);
                    var content = new StringContent(librarianJson, Encoding.UTF8, "application/json");

                    var response = await httpClient.PostAsync(_restpath, content);
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            LibrarianVM librarian = new LibrarianVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    librarian = JsonConvert.DeserializeObject<LibrarianVM>(apiResponse);
                }
            }

            return View(librarian);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(LibrarianVM librarian)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            LibrarianVM result = new LibrarianVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string librarianJSON = System.Text.Json.JsonSerializer.Serialize(librarian);
                    var content = new StringContent(librarianJSON, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{librarian.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<LibrarianVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.DeleteAsync($"{_restpath}/{id}");
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
