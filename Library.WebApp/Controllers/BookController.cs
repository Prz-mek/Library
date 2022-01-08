using Library.WebApp.Models.Book;
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
    public class BookController : Controller
    {
        public IConfiguration Configuration;

        public BookController(IConfiguration configuration)
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

            List<BookVM> booksList = new List<BookVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    booksList = JsonConvert.DeserializeObject<List<BookVM>>(apiResponse);
                }
            }

            return View(booksList);
        }

        public IActionResult Create()
        {
            BookCreateVM book = new BookCreateVM();
            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BookCreateVM book)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string bookJson = System.Text.Json.JsonSerializer.Serialize(book);
                    var content = new StringContent(bookJson, Encoding.UTF8, "application/json");

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

            BookEditVM book = new BookEditVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<BookEditVM>(apiResponse);
                }
            }

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BookEditVM book)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            BookEditVM result = new BookEditVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string bookJSON = System.Text.Json.JsonSerializer.Serialize(book);
                    var content = new StringContent(bookJSON, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{book.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<BookEditVM>(apiResponse);
                    }
                }
            }
            catch (Exception ex)
            {
                return View(ex.Message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            BookDetailsVM book = new BookDetailsVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/details/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    book = JsonConvert.DeserializeObject<BookDetailsVM>(apiResponse);
                }
            }

            return View(book);
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
