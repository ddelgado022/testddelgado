using System.Collections.Generic;
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
                using (var response = await httpClient.GetAsync("http://ss-pre.caas.intel.com/api/SpaceStandard"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                }
            }
            return View(reservationList);
        }
    }
}
