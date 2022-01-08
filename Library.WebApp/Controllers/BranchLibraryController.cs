using Library.WebApp.Models.BranchLibrary;
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
    public class BranchLibraryController : Controller
    {
        public IConfiguration Configuration;

        public BranchLibraryController(IConfiguration configuration)
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

            List<BranchLibraryVM> branchLibrariesList = new List<BranchLibraryVM>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(_restpath))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    branchLibrariesList = JsonConvert.DeserializeObject<List<BranchLibraryVM>>(apiResponse);
                }
            }

            return View(branchLibrariesList);
        }

        public IActionResult Create()
        {
            BranchLibraryCreateVM branchLibrary = new BranchLibraryCreateVM();
            return View(branchLibrary);
        }

        [HttpPost]
        public async Task<IActionResult> Create(BranchLibraryVM branchLibrary)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string branchLibraryJson = System.Text.Json.JsonSerializer.Serialize(branchLibrary);
                    var content = new StringContent(branchLibraryJson, Encoding.UTF8, "application/json");

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

            BranchLibraryVM branchLibrary = new BranchLibraryVM();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"{_restpath}/{id}"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    branchLibrary = JsonConvert.DeserializeObject<BranchLibraryVM>(apiResponse);
                }
            }

            return View(branchLibrary);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BranchLibraryVM branchLibrary)
        {
            string _restpath = GetHostUrl().Content + GetControllerName();

            BranchLibraryVM result = new BranchLibraryVM();

            try
            {
                using (var httpClient = new HttpClient())
                {
                    string branchLibraryJSON = System.Text.Json.JsonSerializer.Serialize(branchLibrary);
                    var content = new StringContent(branchLibraryJSON, Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PutAsync($"{_restpath}/{branchLibrary.Id}", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        result = JsonConvert.DeserializeObject<BranchLibraryVM>(apiResponse);
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
