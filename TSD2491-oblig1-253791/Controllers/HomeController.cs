using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Reflection;
using TSD2491_oblig1_253791.Models;

namespace TSD2491_oblig1_253791.Controllers
{
    public class HomeController : Controller
    {
        private static HomeModel model = new HomeModel();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            SetupGame();
            return View(model); // Gi modellen til view
        }

        private void SetupGame()
        {
            ShuffleList(model.AnimalEmoji);
        }

        private static void ShuffleList<T>(List<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            { // Fisher-Yates Shuffle Algoritme
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

        [HttpPost]
        public ActionResult CheckMatch(int buttonIndex)
        {
            string clickedEmoji = model.AnimalEmoji[buttonIndex];

            if (model.PreviousEmoji == clickedEmoji)
            {
                // Match, fjern sist klikket emoji
                model.AnimalEmoji[buttonIndex] = "";

                // Finn forrige matchende emoji
                for (int i = 0; i < model.AnimalEmoji.Count; i++)
                {
                    if (i != buttonIndex && model.AnimalEmoji[i] == model.PreviousEmoji)
                    {
                        model.AnimalEmoji[i] = ""; // fjern forrige emoji
                        break; 
                    }
                }

                model.PreviousEmoji = null; // reset
            }
            else
            {
                model.PreviousEmoji = clickedEmoji;
            }

            return View("Index", model);
        }
    }
}
