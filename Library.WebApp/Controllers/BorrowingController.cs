using Library.WebApp.Models.Borrowing;
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
    [Authorize(Roles = "Librarian,Admin")]
    public class BorrowingController : Controller
    {
        public IConfiguration Configuration;

        public BorrowingController(IConfiguration configuration)
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

            List<BorrowingVM> borrowingList = new List<BorrowingVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    borrowingList = JsonConvert.DeserializeObject<List<BorrowingVM>>(apiResponse);
                }
            }

            return View(borrowingList);
        }

        public IActionResult Create()
        {
            BorrowingCreateVM borrowing = new BorrowingCreateVM();
            return View(borrowing);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BorrowingCreateVM borrowing)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string borrowingJson = System.Text.Json.JsonSerializer.Serialize(borrowing);
                    var content = new StringContent(borrowingJson, Encoding.UTF8, "application/json");

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

            BorrowingEditVM borrowing = new BorrowingEditVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    borrowing = JsonConvert.DeserializeObject<BorrowingEditVM>(apiResponse);
                }
            }

            return View(borrowing);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BorrowingEditVM borrowing)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            BorrowingEditVM result = new BorrowingEditVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string borrowingJSON = System.Text.Json.JsonSerializer.Serialize(borrowing);
                    var content = new StringContent(borrowingJSON, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{borrowing.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<BorrowingEditVM>(apiResponse);
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

            BorrowingDetailsVM borrowing = new BorrowingDetailsVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/details/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    borrowing = JsonConvert.DeserializeObject<BorrowingDetailsVM>(apiResponse);
                }
            }

            return View(borrowing);
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
