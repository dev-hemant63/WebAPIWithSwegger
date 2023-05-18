using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.AppCode.Interface;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomeAPIController : ControllerBase
    {
        private readonly IEmployeeService _empservice;
        public CustomeAPIController(IEmployeeService empservice)
        {
            _empservice = empservice;
        }
        [HttpGet("GetIP")]
        public IActionResult GetIP()
        {
            string URL = "https://api.ipify.org/?format=json";
            HttpWebRequest http = (HttpWebRequest)System.Net.WebRequest.Create(URL);
            http.Method = "GET";
            http.ContentType = "application/json";
            WebResponse response = http.GetResponse();
            string result = "";
            try
            {
                using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                {
                    result = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            var res = JsonConvert.DeserializeObject<IPdetails>(result);
            return Ok(new
            {
                IP = res.ip
            });
        }
        [HttpGet("{IP}")]
        public IActionResult GetIPDetails(string IP = "")
        {
            if (IP == "")
            {
                string URL = "https://api.ipify.org/?format=json";
                HttpWebRequest http = (HttpWebRequest)System.Net.WebRequest.Create(URL);
                http.Method = "GET";
                http.ContentType = "application/json";
                WebResponse response = http.GetResponse();
                string result = "";
                try
                {
                    using (StreamReader sr = new StreamReader(response.GetResponseStream()))
                    {
                        result = sr.ReadToEnd();
                    }
                }
                catch (Exception ex)
                {

                    throw;
                }
                var res = JsonConvert.DeserializeObject<IPdetails>(result);
                IP = res.ip;
            }

            string uri = "https://ipinfo.io/" + IP + "/geo";
            HttpWebRequest req = (HttpWebRequest)System.Net.WebRequest.Create(uri);
            req.Method = "GET";
            req.ContentType = "application/json";
            WebResponse responses = req.GetResponse();
            string results = "";
            try
            {
                using (StreamReader sr = new StreamReader(responses.GetResponseStream()))
                {
                    results = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            var ress = JsonConvert.DeserializeObject<IPdetails>(results);
            return Ok(ress);
        }
        [HttpGet("GetNewsCategory")]
        public async Task<IActionResult> GetNewsCategory()
        {
            string[] arr = { "business", "entertainment", "general", "health", "science", "sports", "technology" };
            return Ok(new { StatusCode = 1, Msg = "Success", data = arr });
        }
        [HttpPost("GetNews")]
        public IActionResult GetNews(NewsApiParam req)
        {
            var response = new NewsResponse();
            var res = _empservice.GetNews().Result;
            if (res == null)
            {
                var apires = HitNewsApi(req);
                response = apires;
            }
            else
            {
                response = JsonConvert.DeserializeObject<NewsResponse>(res.Resnponse);
            }
            return Ok(response);
        }
        private NewsResponse HitNewsApi(NewsApiParam req)
        {
            string Url = @"https://newsapi.org/v2/top-headlines?sortBy=popularity&country=in&apiKey=c4a56691231d4445957e1a7c6d43882b&pageSize=" + req.PageSize
                            + "&page=" + req.Page + "&category=" + req.Cotegary;
            HttpWebRequest request = (HttpWebRequest)System.Net.WebRequest.Create(Url);
            request.Method = "GET";
            request.ContentType = "application/json";
            var header = new Dictionary<string, string>();
            header.Add("X-Api-Key", "c4a56691231d4445957e1a7c6d43882b");
            foreach (var item in header)
            {
                request.Headers.Add(item.Key, item.Value);
            }
            WebResponse response = request.GetResponse();
            string result = string.Empty;
            try
            {
                using (var stream = new StreamReader(response.GetResponseStream()))
                {
                    result = stream.ReadToEnd();
                    var res = _empservice.AddNews(new GetNewsDB { Request = Url, Resnponse = result }).Result;
                }
            }
            catch (Exception)
            {
                throw;
            }
            var Response = JsonConvert.DeserializeObject<NewsResponse>(result);
            return Response;
        }
    }
}
