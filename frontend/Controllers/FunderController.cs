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
    public class FunderController : Controller
    {
        string Baseurl = "https://localhost:5001";
        string  Baseurl2 = "https://localhost:6001";
        public IActionResult SignUp(){
            ViewBag.alert = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Funder f)
        {
            Funder Pobj = new Funder();
             using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Funder/" + f.Fid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pobj = JsonConvert.DeserializeObject<Funder>(apiResponse);
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

                using (var response = await httpClient.PostAsync("api/Funder", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    Pobj = JsonConvert.DeserializeObject<Funder>(apiResponse);
                }
            }

            HttpContext.Session.SetString("fid", Convert.ToString(f.Fid));
            HttpContext.Session.SetString("log","true");
            return RedirectToAction("GetAllCause");
        }

        
        public async Task<IActionResult> GetAllCause(){
            if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
            List<Cause> causes = new List<Cause>();
            FundReceiver fr = new FundReceiver();
            using (var client = new HttpClient())
            {
                
                client.BaseAddress = new Uri(Baseurl2);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                 HttpResponseMessage Res = await client.GetAsync("/sapi/Cause");
                      
                if (Res.IsSuccessStatusCode)
                {
                    var ApiReponse = Res.Content.ReadAsStringAsync().Result;
                    causes = JsonConvert.DeserializeObject<List<Cause>>(ApiReponse);
                }
              
            }

            return View(causes.Where(x => x.Money > 0).ToList());
        }


        public IActionResult SignIn(){
            ViewBag.alert = false;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInFunder f)
        {
            Funder p = new Funder();
          //  HttpClient obj = new HttpClient();
            
             using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Funder/" + f.Fid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    p = JsonConvert.DeserializeObject<Funder>(apiResponse);
                }
            }
            if (p != null && f.Password.Equals(p.Password.TrimEnd())){
                HttpContext.Session.SetString("fid", f.Fid);
                HttpContext.Session.SetString("log","true");
                return RedirectToAction("GetAllCause");
            } else {
                ViewBag.alert = true;
                return View();
            }
            
        }

        public  IActionResult LogOut() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }
        public async Task<IActionResult> AddFunderCause(int id) {
            if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
            Cause c = new Cause();
            FundReceiver fr = new FundReceiver();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Cause/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Cause>(apiResponse);
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Fundee/" + c.Frid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fr = JsonConvert.DeserializeObject<FundReceiver>(apiResponse);
                }
            }
            FunderCause fc = new FunderCause();
            fc.Cid = id;

            ViewBag.frname = fr.Frname;
            ViewBag.reason = c.Reason;
            ViewBag.money = c.Money;
            return View(fc);
        }

        [HttpPost]
         public async Task<IActionResult> AddFunderCause(FunderCause fc) {
             if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
             fc.Pid = Convert.ToInt32(Convert.ToString(DateTime.Now.Ticks).Substring(0,8));
            fc.Date = DateTime.Now;
            fc.Fid= HttpContext.Session.GetString("fid");
            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl2);
                StringContent content = new StringContent(JsonConvert.SerializeObject(fc), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("/sapi/FunderCause", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            Cause c = new Cause();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Cause/" + fc.Cid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Cause>(apiResponse);
                }
            }
            c.Money = c.Money - fc.Amount;
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

            return RedirectToAction("GetAllCause");
        }

        public async Task<IActionResult> AllFunderCause() {
            if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
            String fid = HttpContext.Session.GetString("fid");            
            List<FunderCause> fc = new List<FunderCause>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:6001/sapi/FunderCause"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fc = JsonConvert.DeserializeObject<List<FunderCause>>(apiResponse);
                }
            }
            return View(fc.Where(x => x.Fid.TrimEnd().Equals(fid)).ToList());
        }

        public IActionResult AccountSettings(){
            if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
            return View();
        }

        [HttpPost]
        [ActionName("AccountSettings")]
        public async Task<IActionResult> AccountSettingsDelete() {
            if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
            string fid = HttpContext.Session.GetString("fid");
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("https://localhost:5001/api/Funder/" + fid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            HttpContext.Session.Clear();
            return RedirectToAction("Index","Home");
        }

        public async Task<IActionResult> CauseDetail(int id) {
            if (HttpContext.Session.GetString("log") == null) {
                return RedirectToAction("SignIn","Home");
            }
            Cause c = new Cause();
            FundReceiver fr = new FundReceiver();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Cause/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Cause>(apiResponse);
                }
            }
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Fundee/" + c.Frid))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fr = JsonConvert.DeserializeObject<FundReceiver>(apiResponse);
                }
            }
            ViewBag.frname = fr.Frname;
            ViewBag.reason = c.Reason;
            ViewBag.money = c.Money;
            return View();
        }

    }
}
