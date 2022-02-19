using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using api.Models;
using Microsoft.AspNetCore.Http;

namespace frontend.Controllers
{
    public class FundeeController : Controller
    {
        string Baseurl = "https://localhost:5001/";
        public IActionResult SignUp(){
            ViewBag.alert = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(FundReceiver f)
        {
            FundReceiver Pobj = new FundReceiver();
             using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Fundee/" + f.Frid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pobj = JsonConvert.DeserializeObject<FundReceiver>(apiResponse);
                }
            }
            if (Pobj != null) {
                ViewBag.alert = true;
                return View();
            }
          //  HttpClient obj = new HttpClient();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(f), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Fundee", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pobj = JsonConvert.DeserializeObject<FundReceiver>(apiResponse);
                }
            }

            HttpContext.Session.SetString("frid", Convert.ToString(f.Frid));
            HttpContext.Session.SetString("log","true");
            return RedirectToAction("CreateCause");
        }

        
        public IActionResult SignIn(){
            ViewBag.alert = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInFundee f)
        {
            FundReceiver p = new FundReceiver();
          //  HttpClient obj = new HttpClient();
            
             using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Fundee/" + f.Frid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<FundReceiver>(apiResponse);
                }
            }
            if (p != null && f.Password.Equals(p.Password.TrimEnd())){
                HttpContext.Session.SetString("frid", f.Frid);
                HttpContext.Session.SetString("log","true");
                return RedirectToAction("AllCause");
            } else {
                ViewBag.alert = true;
                return View();
            }
            
        }

        public  IActionResult LogOut() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> AllCause() {
            if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
            String frid = HttpContext.Session.GetString("frid");            
            List<Cause> fc = new List<Cause>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:6001/sapi/Cause/" + frid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fc = JsonConvert.DeserializeObject<List<Cause>>(apiResponse);
                }
            }

            return View(fc);
        }

        public IActionResult CreateCause() {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateCause(Cause c) {
            c.Cid = Convert.ToInt32(Convert.ToString(DateTime.Now.Ticks).Substring(0,8));
            c.Frid = HttpContext.Session.GetString("frid");
            Cause Cobj = new Cause();
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                StringContent content = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("api/Cause", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Cobj = JsonConvert.DeserializeObject<Cause>(apiResponse);
                }
            }

            return RedirectToAction("AllCause");
        }

        public IActionResult AccountSettings() {
            return View();
        }

        [HttpPost]
        [ActionName("AccountSettings")]
        public async Task<IActionResult> AccountSettingsDelete() {
            if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
            string frid = HttpContext.Session.GetString("frid");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/Fundee/" + frid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> EditCause(int id) {
            Cause c = new Cause();
          //  HttpClient obj = new HttpClient();
            
             using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Cause/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Cause>(apiResponse);
                }
            }

            return View(c);
        }

        [HttpPost]
        public async Task<IActionResult> EditCause(Cause c) {
             
            Cause c1 = new Cause();
            using (var httpClient = new HttpClient())
            {
                StringContent content1 = new StringContent(JsonConvert.SerializeObject(c), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PutAsync("https://localhost:5001/api/Cause/" + c.Cid, content1))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ViewBag.Result = "Success";
                    c1 = JsonConvert.DeserializeObject<Cause>(apiResponse);
                }
            }
            return RedirectToAction("AllCause");
        }

        public async Task<IActionResult> DeleteCause(int id) {
            Cause c = new Cause();
          //  HttpClient obj = new HttpClient();
            
             using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Cause/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Cause>(apiResponse);
                }
            }
            return View(c);
        }

        [HttpPost]
        [ActionName("DeleteCause")]
        public async Task<IActionResult> Delete(int id) {
            Cause c = new Cause();
          //  HttpClient obj = new HttpClient();
            
             using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/Cause/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("AllCause");
        }
    }
}
