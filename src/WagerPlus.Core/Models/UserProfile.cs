using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ladderbot4.Data;

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
        public int LargestWagerPlaced { get; set; } = 0;
        public int LargestWin { get; set; } = 0;
        public int LargestLoss { get; set; } = 0;

        // Trackers
        public DateTime LastDailyReward { get; set; } = DateTime.MinValue;

        public UserProfile(string displayName, ulong discordId)
        {
            DisplayName = displayName;
            DiscordId = discordId;
        }

        public bool IsNewLargestWinRecord(int amount)
        {
            return amount > LargestWin;
        }

        public bool IsNewLargestLossRecord(int amount)
        {
            return amount > LargestLoss;
        }

        public bool IsNewLargestWagerPlaced(int amount)
        {
            return amount > LargestWagerPlaced;
        }

        public bool CanClaimDailyReward()
        {
            return DateTime.Now >= LastDailyReward.AddHours(24);
        }

        public TimeSpan GetDailyRewardCooldown()
        {
            DateTime nextClaimTime = LastDailyReward.AddHours(24);
            return nextClaimTime - DateTime.Now;
        }

    }
}
