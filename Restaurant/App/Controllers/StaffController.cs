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
    public class StaffController : Controller
    {
        // GET: Staff
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get Method
                HttpResponseMessage response = await client.GetAsync("api/staff/GetAll");
                if (response.IsSuccessStatusCode)// 200-299 is success code
                {
                    var members = await response.Content.ReadAsAsync<staff[]>();
                    List<staff> memberList = members.ToList();
                    return View(memberList);
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
                HttpResponseMessage response = await client.GetAsync($"api/staff/GetById/{id}");
                if (response.IsSuccessStatusCode) //200-299
                {
                    var members = await response.Content.ReadAsAsync<staff>();

                    return View(members);
                }
                else
                {
                    return View();
                }
            }
        }

        [HttpGet]
        public ActionResult SaveMember() //SaveMember
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> SaveMember(staff memb)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/"); //http://localhost:59542/api/Item/AddItem
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.PostAsJsonAsync("api/staff/AddMember", memb);
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

        public ActionResult DeleteMember() //DeleteMember
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> DeleteMember(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/"); //http://localhost:59542/api/Item/RemoveItem/{id}
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                HttpResponseMessage response = await client.DeleteAsync($"api/staff/RemoveMember/{id}");
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
        public ActionResult UpdateMember() //UpdateMember
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> UpdateMember(staff memb)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:62846/"); //http://localhost:59542/api/Item/UpdateItem
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Get by id Method
                HttpResponseMessage response = await client.PutAsJsonAsync($"api/staff/UpdateMember", memb);
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