using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.WagerCommands
{
    public class CreateWagerLogic : Logic
    {
        private PoolManager _poolManager;
        private WagerManager _wagerManager;

        public CreateWagerLogic(PoolManager poolManager, WagerManager wagerManager) : base("Create Wager")
        {
            _poolManager = poolManager;
            _wagerManager = wagerManager;
        }

        public string CreateWagerProcess(SocketInteractionContext context, string poolName, PoolChoice choice, int wagerAmount, string? description = null)
        {
            // Check if pool by given name exists
            if (!_poolManager.IsPoolNameUnique(poolName))
            {
                // Grab pool
                Pool? pool = _poolManager.GetPoolByName(poolName);

                // Check if pool is open for wagers
                if (_poolManager.IsPoolOpen(pool))
                {
                    // Check if user has already placed wager in pool
                    if (!_wagerManager.IsUserInWagersList(context.User.Id, pool.Wagers))
                    {
                        // Create wager and add to pool
                        Wager newWager = new(context.User.Id, context.User.Username, choice, wagerAmount, pool.GetOddsForChoice(choice), description);
                        pool.AddWagerToList(newWager);

                        // Save and reload
                        _poolManager.SaveAndReloadBettingPoolsDatabase();

                        return $"{newWager.DisplayName} ({newWager.DiscordId}) has created a new wager in {pool.Name}. Choice: {newWager.Choice} - Amount: {newWager.Amount}";
                    }
                    return $"User with the given ID already found in Wagers list in given pool. ID: {context.User.Id} - Pool: {pool.Name}";
                }
                return $"{pool.Name} is not currently open for wagers yet.";
            }
            return $"The pool name given was not found in the database: {poolName}";
        }
    }
}
