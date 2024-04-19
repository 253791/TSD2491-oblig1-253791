namespace TSD2491_oblig1_253791.Models
{
    public class HomeModel
    {
        public List<string> AnimalEmoji { get; set; }
        public List<string> FoodEmoji { get; set; }
        public List<string> BallEmoji { get; set; }
        public static string PreviousEmoji { get; set; } = string.Empty;
        public string CurrentEmojiTable { get; set; }
        public static List<string> DisplayedEmojis { get; set; } = new List<string>();
        public string GameStatus { get; set; } = "";
        public static int NumberMatched { get; set; }

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

            FoodEmoji = new List<string>()
            {
                "🍆", "🍆",
                "🍕", "🍕",
                "🌭", "🌭",
                "🥪", "🥪",
                "🍟", "🍟",
                "🍔", "🍔",
                "🍝", "🍝",
                "🍙", "🍙",
            };

            BallEmoji = new List<string>()
            {
                "⚽", "⚽",
                "⚾", "⚾",
                "🏀", "🏀",
                "🏐", "🏐",
                "🏈", "🏈",
                "🥎", "🥎",
                "🔮", "🔮",
                "🎱", "🎱",
            };
        }
        public static List<User> RegisteredUsers { get; set; } = new List<User>();

        public class User
        {
            public string? Username { get; set; }
            public int GamesPlayed { get; set; }
        }
    }
}
