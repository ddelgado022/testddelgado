﻿using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MyWebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;


namespace MyWebApp.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Reservation> reservationList = new List<Reservation>();
            using (var httpClient = new HttpClient())
            {
                //using (var response = await httpClient.GetAsync("http://ss-pre.caas.intel.com/api/SpaceStandard"))
                using (var response = await httpClient.GetAsync("https://www.7timer.info/bin/astro.php?lon=113.2&lat=23.1&ac=0&unit=metric&output=json&tzshift=0"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    apiResponse = "[" + apiResponse + "]";

                    reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                    
                }
            }
            return View(reservationList);
        }
    }
}
