using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TSD2491_oblig1_253791.Models;


namespace TSD2491_oblig1_253791.Controllers
{
    public class HomeController : Controller
    {
        private HomeModel model = new HomeModel();
        private bool gameIsWon = false;
        private bool userPressed;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            HomeModel.DisplayedEmojis.Clear();
            RandomizeEmojiTable();
            SetupGame();
            return View(model); // Gi modellen til view
        }

        private void RandomizeEmojiTable()
        {
            var possibleTables = new List<string> { "AnimalEmoji", "FoodEmoji", "BallEmoji" };
            Random random = new Random();
            int randomIndex = random.Next(possibleTables.Count);
            model.CurrentEmojiTable = possibleTables[randomIndex];
        }

        private void SetupGame()
        {
            switch (model.CurrentEmojiTable)
            {
                case "FoodEmoji":
                    HomeModel.DisplayedEmojis.AddRange(model.FoodEmoji);
                    break;
                case "BallEmoji":
                    HomeModel.DisplayedEmojis.AddRange(model.BallEmoji);
                    break;
                case "AnimalEmoji":
                    HomeModel.DisplayedEmojis.AddRange(model.AnimalEmoji);
                    break;
            }
            ShuffleList(HomeModel.DisplayedEmojis);
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

        public ActionResult CheckMatch(int buttonIndex)
        {
            userPressed = true;
            string clickedEmoji = HomeModel.DisplayedEmojis[buttonIndex];

            if (HomeModel.PreviousEmoji == clickedEmoji)
            {
                HomeModel.NumberMatched++;
                for (int i = 0; i < HomeModel.DisplayedEmojis.Count; i++)
                {
                    if (HomeModel.DisplayedEmojis[i] == clickedEmoji)
                    {
                        HomeModel.DisplayedEmojis[i] = ""; // fjern forrige emoji
                    }
                }

                HomeModel.PreviousEmoji = null; // reset
            }
            else
            {
                HomeModel.PreviousEmoji = clickedEmoji;
            }
            if (HomeModel.NumberMatched == 8)
            {
                HomeModel.NumberMatched = 0;
                gameIsWon = true;
            }
            if (userPressed == true)
            {
                model.GameStatus = "Game Running";
            }
            if (gameIsWon)
            {
                userPressed = false;
                model.GameStatus = "Game Complete";
            }

            return View("Index", model);
        }
        public IActionResult NewGame()
        {
            return RedirectToAction("Index"); // Redirect to refresh with new emojis
        }
    }
}
