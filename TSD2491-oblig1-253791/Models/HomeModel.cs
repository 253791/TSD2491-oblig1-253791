﻿namespace TSD2491_oblig1_253791.Models
{
    public class HomeModel
    {
        public List<string> AnimalEmoji { get; set; }
        public List<string> FoodEmoji { get; set; }
        public List<string> BallEmoji { get; set; }
        public static string PreviousEmoji { get; set; } = string.Empty;
        public string CurrentEmojiTable { get; set; }
        public static List<string> DisplayedEmojis { get; set; } = new List<string>();

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
    }
}
