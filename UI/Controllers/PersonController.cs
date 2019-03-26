using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using UI.Models;

namespace UI.Controllers
{
    public class PersonController : BaseController
    {
        public async Task<ActionResult> Index()
        {
            try
            {
                var list = new List<PersonViewModel>();

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("Person");
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        
                        list = JsonConvert.DeserializeObject<List<PersonViewModel>>(data);
                    }
                }
                return View(list);
            }
            catch
            {
                TempData["Failure"] = "Error retrieving data.";
                return View(new List<PersonViewModel>());
            }
        }

        public async Task<ActionResult> Details(int id)
        {
            try
            {
                var person = new PersonViewModel();

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"Person/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        person = JsonConvert.DeserializeObject<PersonViewModel>(data);
                    }
                }
                return View(person);
            }
            catch
            {
                TempData["Failure"] = "Error retrieving data.";
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(PersonViewModel model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsync("Person", GetHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<PersonViewModel>(data);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"{response.ReasonPhrase}: {response.Content.ReadAsStringAsync().Result}");
                        return View(model);
                    }
                }
                TempData["Success"] = "Created Successfully!";
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                TempData["Failure"] = "Server error.";
                return View();
            }
        }

        public async Task<ActionResult> Edit(int id)
        {
            try
            {
                var person = new PersonViewModel();

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"Person/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        person = JsonConvert.DeserializeObject<PersonViewModel>(data);
                    }
                }
                return View(person);
            }
            catch
            {
                TempData["Failure"] = "Error retrieving data.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(int id, PersonViewModel model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PutAsync("Person", GetHttpContent(model));
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        model = JsonConvert.DeserializeObject<PersonViewModel>(data);
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, $"{response.ReasonPhrase}: {response.Content.ReadAsStringAsync().Result}");
                        return View(model);
                    }
                }
                TempData["Success"] = "Edited Successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Failure"] = "Server error.";
                return View();
            }
        }

        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var person = new PersonViewModel();

                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync($"Person/{id}");
                    if (response.IsSuccessStatusCode)
                    {
                        var data = await response.Content.ReadAsStringAsync();
                        person = JsonConvert.DeserializeObject<PersonViewModel>(data);
                    }
                }
                return View(person);
            }
            catch
            {
                TempData["Failure"] = "Error retrieving data.";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id, PersonViewModel model)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(API_URL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                    await client.DeleteAsync($"Person/{id}");
                }
                TempData["Success"] = "Deleted Successfully!";
                return RedirectToAction("Index");
            }
            catch
            {
                TempData["Failure"] = "Server error.";
                return View();
            }
        }
    }
}
