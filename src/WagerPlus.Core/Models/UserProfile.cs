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
        public required string DisplayName { get; set; }
        public required ulong DiscordId { get; set; }

        // Currency
        public int CurrencyAmount { get; set; }

        public UserProfile(string displayName, ulong discordId)
        {
            DisplayName = displayName;
            DiscordId = discordId;
            // TODO: Decide on starting amount for new Users
            CurrencyAmount = 50;
        }
    }
}
