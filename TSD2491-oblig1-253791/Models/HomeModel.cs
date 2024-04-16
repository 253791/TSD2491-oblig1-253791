using Microsoft.AspNetCore.Mvc;

namespace TSD2491_oblig1_253791.Models
{
    public class HomeModel
    {
        public List<string> AnimalEmoji { get; set; }
        public string PreviousEmoji { get; set; }

        public HomeModel()
        {
            AnimalEmoji = new List<string>()
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
        }
    }
}
