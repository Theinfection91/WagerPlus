using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models
{
    public class MetaWager
    {
        // Id and Name
        public string BettorId { get; set; }
        public string BettorName { get; set; }
        
        // The meta team being wagered on
        public MetaTeam Target { get; set; }

        // Amount and Odds
        public int Amount { get; set; }
        public decimal Odds { get; set; }

        // Timestamp
        public DateTime CreatedOn { get; set; }

        public MetaWager(string bettorId, string bettorName, MetaTeam target, int amount, decimal odds, DateTime createdOn)
        {
            BettorId = bettorId;
            BettorName = bettorName;
            Target = target;
            Amount = amount;
            Odds = odds;
            CreatedOn = createdOn;
        }
    }
}
