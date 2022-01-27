using Library.WebApp.Models.Reader;
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
    public class ReaderController : Controller
    {
        public IConfiguration Configuration;

        public ReaderController(IConfiguration configuration)
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

            List<ReaderVM> readerList = new List<ReaderVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    readerList = JsonConvert.DeserializeObject<List<ReaderVM>>(apiResponse);
                }
            }

            return View(readerList);
        }

        public IActionResult Create()
        {
            ReaderCreateVM reader = new ReaderCreateVM();
            return View(reader);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ReaderCreateVM reader)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string readerJson = System.Text.Json.JsonSerializer.Serialize(reader);
                    var content = new StringContent(readerJson, Encoding.UTF8, "application/json");

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

            ReaderEditVM reader = new ReaderEditVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reader = JsonConvert.DeserializeObject<ReaderEditVM>(apiResponse);
                }
            }

            return View(reader);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ReaderEditVM reader)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            ReaderEditVM result = new ReaderEditVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string readerJSON = System.Text.Json.JsonSerializer.Serialize(reader);
                    var content = new StringContent(readerJSON, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{reader.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<ReaderEditVM>(apiResponse);
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

            ReaderDetailsVM reader = new ReaderDetailsVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/details/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reader = JsonConvert.DeserializeObject<ReaderDetailsVM>(apiResponse);
                }
            }

            return View(reader);
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
