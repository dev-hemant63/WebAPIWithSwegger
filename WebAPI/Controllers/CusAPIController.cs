using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CusAPIController : ControllerBase
    {
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
                IP= res.ip
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
    }
}
