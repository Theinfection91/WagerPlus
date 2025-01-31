using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Core.Models
{
    public class Wager
    {
        // Id and Name are from UserProfile that creates the Wager
        public ulong DiscordId { get; set; }
        public string DisplayName { get; set; }
        public string? Description { get; set; }
        
        // The user's choice
        public PoolChoice Choice { get; set; }

        // Wager and Odds amount
        public int Amount { get; set; }
        public decimal Odds { get; set; }

        // Timestamp
        public DateTime CreatedOn { get; set; }

        public Wager(ulong discordId, string displayName, PoolChoice choice, int wagerAmount, decimal odds, string? description = null)
        {
            DiscordId = discordId;
            DisplayName = displayName;
            Description = description;
            Choice = choice;
            Amount = wagerAmount;
            Odds = odds;
            CreatedOn = DateTime.Now;
        }
    }
}
