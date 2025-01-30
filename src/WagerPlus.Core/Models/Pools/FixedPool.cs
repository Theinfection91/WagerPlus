using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Core.Models.Pools
{
    public class FixedPool : Pool
    {
        public decimal ChoiceOneFixedOdds { get; set; } = 1.2m;
        public decimal ChoiceTwoFixedOdds { get; set; } = 1.5m;

        public FixedPool(string name, PoolType poolType, ulong ownerDiscordId, string ownerDisplayName, string? description = null) : base(name, poolType, ownerDiscordId, ownerDisplayName, description)
        {

        }

        public int GetProjectedPayoutBasedOnWager(PoolChoice choice, int wagerAmount)
        {
            decimal odds = choice == PoolChoice.ChoiceOne ? ChoiceOneFixedOdds : ChoiceTwoFixedOdds;

            // Return total payout including original wager
            return (int)(wagerAmount * odds);
        }


        public void EditChoiceFixedOddsAmount(PoolChoice choice, decimal amount)
        {
            if (choice == PoolChoice.ChoiceOne)
            {
                ChoiceOneFixedOdds = amount;
            }
            else if (choice == PoolChoice.ChoiceTwo)
            {
                ChoiceTwoFixedOdds = amount;
            }
        }
    }
}
