using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using DAL.Models;
using System.Threading.Tasks;

namespace App.Controllers
{
    public class ItemController : Controller
    {
        // GET: Item
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/"); //http://localhost:59542/api/Item/GetAll This is complete URL
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get Method
                HttpResponseMessage response = await client.GetAsync("api/Item/GetAll");
                if (response.IsSuccessStatusCode)// 200-299 is success code
                {
                    var items = await response.Content.ReadAsAsync<Item[]>();
                    List<Item> itemList = items.ToList();
                    return View(itemList);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetById(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/"); //http://localhost:59542/api/Item/GetById/{Id}
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get by id Method
                HttpResponseMessage response = await client.GetAsync($"api/Item/GetById/{id}");
                if (response.IsSuccessStatusCode) //200-299
                {
                    var items = await response.Content.ReadAsAsync<Item>();

                    return View(items);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult SaveItem() //SaveItem
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveItem(Item item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/"); //http://localhost:59542/api/Item/AddItem
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get by id Method
                HttpResponseMessage response = await client.PostAsJsonAsync("api/Item/AddItem", item);
                if (response.IsSuccessStatusCode) //200-299
                {

                    return RedirectToAction("GetAll");
                }
                else
                {
                    return View();
                }
            }
        }

        public ActionResult DeleteItem() //DeleteItem
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteItem(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/"); //http://localhost:59542/api/Item/RemoveItem/{id}
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get by id Method
                HttpResponseMessage response = await client.DeleteAsync($"api/Item/RemoveItem/{id}");
                if (response.IsSuccessStatusCode) //200-299
                {

                    return RedirectToAction("GetAll");
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult UpdateItem() //UpdateItem
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateItem(Item item)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/"); //http://localhost:59542/api/Item/UpdateItem
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get by id Method
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/Item/UpdateItem", item);
                if (response.IsSuccessStatusCode) //200-299
                {

                    return RedirectToAction("GetAll");
                }
                else
                {
                    return View();
                }
            }
        }
    }
}