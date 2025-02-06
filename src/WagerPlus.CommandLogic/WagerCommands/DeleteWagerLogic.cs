using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using Discord.WebSocket;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.WagerCommands
{
    public class DeleteWagerLogic
    {
        private ConfigManager _configManager;
        private CurrencyManager _currencyManager;
        private PoolManager _poolManager;
        private UserProfileManager _userProfileManager;
        private WagerManager _wagerManager;

        public DeleteWagerLogic(ConfigManager configManager, CurrencyManager currencyManager, PoolManager poolManager, UserProfileManager userProfileManager, WagerManager wagerManager)
        {
            _configManager = configManager;
            _currencyManager = currencyManager;
            _poolManager = poolManager;
            _userProfileManager = userProfileManager;
            _wagerManager = wagerManager;
        }

        public string DeleteWagerProcess(SocketInteractionContext context, string poolId, ulong wagerDiscordId)
        {
            // Check if given Id is in database
            if (!_poolManager.IsPoolIdInDatabase(poolId))
                return $"Given pool ID not found in Database: {poolId}";

            // Grab pool
            Pool? pool = _poolManager.GetPoolById(poolId);

            // Check if invoker is owner of pool (or admin)
            if (context.User is not SocketGuildUser guildUser)
                return "This command must be used in a guild.";
            bool IsAdmin = guildUser.GuildPermissions.Administrator;
            if (!_poolManager.IsUserPoolOwner(context.User.Id, pool) && !_configManager.IsDeputyAdmin(context.User.Id) && !IsAdmin)
                return $"You are not the owner of {pool.Id}, nor do you have Guild or Deputy Admin permissions... {pool.OwnerDisplayName} is the owner.";

            // Make sure Id has a registered UserProfile
            if (_userProfileManager.IsUserRegistered(wagerDiscordId))
                return "The given ID doesn't not a have profile registered for wagers.";

            // Grab profile
            UserProfile? userProfile = _userProfileManager.GetUserProfile(wagerDiscordId);

            // Check if given discord Id has wager in pool
            if (!_wagerManager.IsUserInWagersList(wagerDiscordId, pool.Wagers))
                return $"No wagers for {wagerDiscordId} was found in {pool.Id}.";

            // Grab wager
            Wager? wager = _wagerManager.GetWagerInPoolFromDiscordId(pool, wagerDiscordId);

            // Refund the user's wager amount
            _currencyManager.AddAmountToUserCurrency(userProfile, wager.Amount);

            // Remove the wager
            _wagerManager.RemoveWagerFromPool(pool, wager);

            return $"{wagerDiscordId} ({userProfile.DisplayName}) has successfully had their wager deleted in {pool.Id} and their amount ({wager.Amount}) refunded.";
        }
    }
}
