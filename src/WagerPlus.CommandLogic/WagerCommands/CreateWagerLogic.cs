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
        private CurrencyManager _currencyManager;
        private PoolManager _poolManager;
        private UserProfileManager _userProfileManager;
        private WagerManager _wagerManager;

        public CreateWagerLogic(CurrencyManager currencyManager, PoolManager poolManager, UserProfileManager userProfileManager, WagerManager wagerManager) : base("Create Wager")
        {
            _currencyManager = currencyManager;
            _poolManager = poolManager;
            _userProfileManager = userProfileManager;
            _wagerManager = wagerManager;
        }

        public string CreateWagerProcess(SocketInteractionContext context, string poolId, PoolChoice choice, int wagerAmount, string? description = null)
        {
            // Check if pool by given name exists
            if (_poolManager.IsPoolIdInDatabase(poolId))
            {
                // Grab pool
                Pool? pool = _poolManager.GetPoolById(poolId);

                // Check if pool is open for wagers
                if (_poolManager.IsPoolOpen(pool))
                {
                    // Get user profile
                    UserProfile? userProfile = _userProfileManager.GetUserProfile(context.User.Id);

                    // Check if user has already placed wager in pool
                    if (!_wagerManager.IsUserInWagersList(userProfile.DiscordId, pool.Wagers))
                    {
                        // Check if user has enough currency for given wager amount
                        if (_currencyManager.HasEnoughFunds(userProfile, wagerAmount))
                        {
                            // Check if wager will net any profit
                            if (_wagerManager.IsWagerProfitable(wagerAmount, pool.GetMinimumBetForProfit(choice)))
                            {
                                // Create wager and add to pool
                                Wager newWager = new(context.User.Id, context.User.Username, choice, wagerAmount, pool.GetOddsForChoice(choice), description);
                                pool.AddWagerToList(newWager);

                                // Save and reload
                                _poolManager.SaveAndReloadBettingPoolsDatabase();

                                return $"{newWager.DisplayName} ({newWager.DiscordId}) has created a new wager in {pool.Name}. Choice: {newWager.Choice} - Amount: {newWager.Amount}";
                            }
                            return $"A wager amount of {wagerAmount} at {pool.GetOddsForChoice(choice)} would not net any profit. The minimum bet at those odds would be **{pool.GetMinimumBetForProfit(choice)}**";
                        }
                        return $"Not enough funds for given wager amount. Wager Amount: {wagerAmount} - Total Currency: {userProfile.Currency.GetTotalCurrency()}";
                    }
                    return $"User with the given ID already found in Wagers list in given pool. ID: {context.User.Id} - Pool: {pool.Name}";
                }
                return $"{pool.Name} is not currently open for wagers yet.";
            }
            return $"The pool Id given was not found in the database: {poolId}";
        }
    }
}
