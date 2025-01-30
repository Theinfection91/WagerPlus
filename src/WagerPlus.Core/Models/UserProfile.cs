using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Models
{
    public class UserProfile
    {
        // Name and Discord ID
        public string DisplayName { get; set; }
        public ulong DiscordId { get; set; }

        // Currency
        public required Currency Currency { get; set; }

        // Stats
        public int WagersWon { get; set; } = 0;
        public int WagersLost { get; set; } = 0;
        public int LargestWin { get; set; } = 0;
        public int LargestLoss { get; set; } = 0;

        public UserProfile(string displayName, ulong discordId)
        {
            DisplayName = displayName;
            DiscordId = discordId;
        }
    }
}
