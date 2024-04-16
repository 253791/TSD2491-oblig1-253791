using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSD2491_oblig1_253791.Models;

namespace TSD2491_oblig1_253791.Controllers
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
            List<string> animalEmoji = new List<string>()
            {
                "🐤", "🐤",
                "🐷", "🐷",
                "🐭", "🐭",
                "🐯", "🐯",
                "🐰", "🐰",
                "🐼", "🐼",
                "🦁", "🦁",
                "🐮", "🐮",
            };

            List<string> shuffledAnimals = new List<string>();

            ViewData["AnimalEmoji"] = animalEmoji;
            SetUpGame();
            return View();
        }

        private void SetUpGame()
        {
            var animalEmoji = ViewData["AnimalEmoji"] as List<string>;
            if (animalEmoji != null)
            {
                ShuffleList(animalEmoji);           
            }
        }

        private static void ShuffleList<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            { // Fisher-Yates Shuffle Algorithm
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
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
