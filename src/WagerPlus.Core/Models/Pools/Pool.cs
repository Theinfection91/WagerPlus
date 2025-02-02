using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Core.Models.Pools
{
    public class Pool
    {
        // Basic Info
        public string Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public PoolType Type { get; set; }
        public DateTime CreatedOn { get; set; }

        // Targets
        public Dictionary<int, Target> Targets { get; set; }
        public bool IsTargetsLocked { get; set; }

        // Odds
        public decimal TargetOneOdds { get; set; } 
        public decimal TargetTwoOdds { get; set; } 

        // Dynamic Info
        public PoolStatus Status { get; set; }
        public List<Wager> Wagers { get; set; }
        public int TargetOneWagerCount => GetWagerCount(PoolTarget.Target_1);
        public int TargetOnePotTotal => GetTargetPotTotal(PoolTarget.Target_1);
        public int TargetTwoWagerCount => GetWagerCount(PoolTarget.Target_2);
        public int TargetTwoPotTotal => GetTargetPotTotal(PoolTarget.Target_2);
        public int PotTotal => GetBothTargetsPotTotal();

        // Target Winner
        public PoolTarget WinningTarget { get; set; }
        public bool IsWinningTargetSet { get; set; }

        // Status Timestamps
        public DateTime Opened { get; set; }
        public DateTime Closed { get; set; }
        public DateTime Resolved { get; set; }

        // Creator Info
        public ulong OwnerDiscordId { get; set; }
        public string OwnerDisplayName { get; set; }
        public bool IsFresh { get; set; }

        public Pool(string name, PoolType poolType, ulong ownerDiscordId, string ownerDisplayName, string? description = null)
        {
            Name = name;
            Description = description ?? string.Empty;
            Type = poolType;
            CreatedOn = DateTime.UtcNow;
            Targets = [];
            IsTargetsLocked = false;
            IsWinningTargetSet = false;
            Status = PoolStatus.Closed;
            Wagers = [];
            OwnerDiscordId = ownerDiscordId;
            OwnerDisplayName = ownerDisplayName;
            IsFresh = true;
        }

        public void AddTargetToDictionary(Target target)
        {
            Targets.Add(Targets.Count + 1, target);
        }

        public void AddWagerToList(Wager wager)
        {
            Wagers.Add(wager);
        }

        public void RemoveWagerFromList(Wager wagerRef)
        {
            foreach (Wager wager in Wagers)
            {
                if (wager.DiscordId.Equals(wagerRef.DiscordId))
                {
                    Wagers.Remove(wager);
                }
            }
        }

        public bool IsTargetsFull()
        {
            return Targets.Count >= 2;
        }

        public bool IsOddsDifferent()
        {
            return TargetOneOdds != TargetTwoOdds;
        }

        public string GetNameForTarget(PoolTarget poolTarget)
        {
            foreach(var target in Targets.Values)
            {
                if (target.PoolTarget.Equals(poolTarget))
                {
                    return target.Name;
                }
            }
            return "oops";
        }

        public int GetProjectedPayoutBasedOnWager(PoolTarget target, int wagerAmount)
        {
            decimal odds = target == PoolTarget.Target_1 ? TargetOneOdds : TargetTwoOdds;

            // Return total payout including original wager
            return (int)(wagerAmount * odds);
        }

        public int GetWagerCount(PoolTarget target)
        {
            int count = 0;
            foreach (Wager wager in Wagers)
            {
                if (wager.Target.Equals(target))
                {
                    count++;
                    return count;
                }
            }
            return count;
        }

        public int GetTargetPotTotal(PoolTarget target)
        {
            int total = 0;
            foreach (Wager wager in Wagers)
            {
                if (wager.Target.Equals(target))
                {
                    total += wager.Amount;
                }
            }
            return total;
        }

        public int GetBothTargetsPotTotal()
        {
            return TargetOnePotTotal + TargetTwoPotTotal;
        }

        public void EditChoiceOddsAmount(PoolTarget target, decimal amount)
        {
            if (amount >= 1.00m)
            {
                if (target == PoolTarget.Target_1)
                {
                    TargetOneOdds = amount;
                }
                else if (target == PoolTarget.Target_2)
                {
                    TargetTwoOdds = amount;
                }
            }
        }

        public int GetMinimumBetForProfit(PoolTarget target)
        {
            decimal odds;

            if (target == PoolTarget.Target_1)
            {
                odds = TargetOneOdds;
            }
            else if (target == PoolTarget.Target_2)
            {
                odds = TargetTwoOdds;
            }
            else
            {
                return 0;
            }

            return (int)Math.Ceiling(1 / (odds - 1));
        }

        public decimal GetOddsForChoice(PoolTarget target)
        {
            if (target == PoolTarget.Target_1)
            {
                return TargetOneOdds;
            }
            else if (target == PoolTarget.Target_2)
            {
                return TargetTwoOdds;
            }

            return 0;
        }

        public void ClearWagers()
        {
            Wagers.Clear();
        }
    }
}
