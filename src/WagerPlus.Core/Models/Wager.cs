using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums;

namespace WagerPlus.Core.Models
{
    public class Wager
    {
        // Id and Name are from UserProfile that creates the Wager
        public required ulong DiscordId { get; set; }
        public required string DisplayName { get; set; }
        public string? Description { get; set; }
        
        // The user's choice
        public required Choice Choice { get; set; }

        // Wager amount
        public required int Amount { get; set; }

        // Timestamp
        public DateTime CreatedOn { get; set; }
    }
}
