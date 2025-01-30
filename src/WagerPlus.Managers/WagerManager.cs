using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;

namespace WagerPlus.Managers
{
    public class WagerManager : DataDriven
    {
        public WagerManager(DataManager dataManager) : base("WagerManager", dataManager)
        {

        }

        public bool IsUserInWagersList(ulong discordId, List<Wager> wagers)
        {
            foreach (Wager wager in wagers)
            {
                if (discordId.Equals(wager.DiscordId))
                {
                    return true;
                }
            }
            return false;
        }

        public Wager? GetWagerInPoolFromDiscordId(Pool pool, ulong discordId)
        {
            foreach (Wager wager in pool.Wagers)
            {
                if (wager.DiscordId.Equals(discordId))
                {
                    return wager;
                }
            }
            return null;
        }

        public List<Wager> GetAllWagersByDiscordId(ulong discordId)
        {
            List<Wager> allWagers = [];
            foreach(Pool pool in _dataManager.BettingPoolsDatabase.Pools)
            {
                foreach (Wager wager in pool.Wagers)
                {
                    if (wager.DiscordId.Equals(discordId))
                    {
                        allWagers.Add(wager);
                    }
                }
            }
            return allWagers;
        }

        public void AddWagerToPool(Pool pool, Wager wager)
        {
            pool.AddWagerToList(wager);
            _dataManager.SaveAndReloadBettingPoolsDatabase();
        }
    }
}
