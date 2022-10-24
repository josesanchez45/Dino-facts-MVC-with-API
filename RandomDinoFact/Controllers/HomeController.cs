using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RandomDinoFact.Models;
using System.Diagnostics;

namespace RandomDinoFact.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var client = new HttpClient();
            var url = "https://dinosaur-facts-api.shultzlab.com/dinosaurs/random";
            var response = client.GetStringAsync(url).Result;
            var root = JsonConvert.DeserializeObject<DinoRoot>(response);
            return View(root);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}