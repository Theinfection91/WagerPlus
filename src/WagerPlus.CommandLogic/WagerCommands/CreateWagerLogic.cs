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

        public string CreateWagerProcess(SocketInteractionContext context, string poolId, PoolTarget target, int wagerAmount, string? description = null)
        {
            // Check if wager is greater than 0
            if (wagerAmount < 0)
                return $"A wager amount can not be 0 or less.";

            // Check if given Id is in database
            if (!_poolManager.IsPoolIdInDatabase(poolId))
                return $"Given pool ID not found in Database: {poolId}";

            // Grab pool
            Pool? pool = _poolManager.GetPoolById(poolId);

            // Check if pool is open for wagers
            if (!_poolManager.IsPoolOpen(pool))
                return $"{pool.Id} is not currently open for wagers yet.";

            // Get user profile
            UserProfile? userProfile = _userProfileManager.GetUserProfile(context.User.Id);
            if (userProfile == null)
                return $"Could not pull UserProfile from discord Id - {context.User.Id}";

            // Check if user has already placed wager in pool
            if (_wagerManager.IsUserInWagersList(userProfile.DiscordId, pool.Wagers))
                return $"User with the given ID already found in Wagers list in given pool. ID: {context.User.Id} - Pool: {pool.Id}";

            // Check if user has enough currency for given wager amount
            if (!_currencyManager.HasEnoughFunds(userProfile, wagerAmount))
                return $"Not enough funds for given wager amount. Wager Amount: {wagerAmount} - Total Currency: {userProfile.Currency.GetTotalCurrency()}";

            // Check if wager will net any profit
            if (!_wagerManager.IsWagerProfitable(wagerAmount, pool.GetMinimumBetForProfit(target)))
                return $"A wager amount of {wagerAmount} at {pool.GetOddsForChoice(target)} would not net any profit. The minimum wager amount you can place at those odds would be **{pool.GetMinimumBetForProfit(target)}**";

            // Subtract wager amount from user
            _currencyManager.SubtractAmountFromUserCurrency(userProfile, wagerAmount);

            // Create wager and add to pool
            Wager newWager = new(context.User.Id, context.User.Username, target, wagerAmount, pool.GetOddsForChoice(target), description);
            pool.AddWagerToList(newWager);

            // Check if wager is new record
            if (userProfile.IsNewLargestWagerPlaced(newWager.Amount))
                _userProfileManager.SetNewWagerPlacedRecord(userProfile, newWager.Amount);

            // Save and reload
            _poolManager.SaveAndReloadBettingPoolsDatabase();
            _userProfileManager.SaveAndReloadUserProfileList();

            return $"{newWager.DisplayName} ({newWager.DiscordId}) has created a new wager in {pool.Id}. Target: {newWager.Target} - Amount: {newWager.Amount}";
        }
    }
}
