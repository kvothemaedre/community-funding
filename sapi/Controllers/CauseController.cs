using sapi.Models;
using sapi.Repo;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace sapi.Controllers
{
    [Route("sapi/[controller]")]
    [ApiController]
    public class CauseController : ControllerBase
    {
        // GET api/<ProductController>/5
       
        [HttpGet("{frid}")]
        public async Task<List<Cause>> GetCauses(string frid)
        {
            string Baseurl = "https://localhost:5001/";
            List<Cause> causes = new List<Cause>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Cause");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ApiResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    causes = JsonConvert.DeserializeObject<List<Cause>>(ApiResponse);
                    
                    return causes.Where(x => x.Frid.TrimEnd().Equals(frid)).ToList();
                }
                else
                {
                    return null;
                }

            }
        }  

        [HttpGet]
        public async Task<List<Cause>> AllCauses()
        {
            string Baseurl = "https://localhost:5001/";
            List<Cause> causes = new List<Cause>();

            using (var client = new HttpClient())
            {
                //Passing service base url  
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Cause");

                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var ApiResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    causes = JsonConvert.DeserializeObject<List<Cause>>(ApiResponse);
                    
                    return causes;
                }
                else
                {
                    return null;
                }

            }
        }        
    }
}
