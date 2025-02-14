using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using Discord.WebSocket;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class DeletePoolLogic : Logic
    {
        private ConfigManager _configManager;
        private CurrencyManager _currencyManager;
        private PoolManager _poolManager;
        private UserProfileManager _userProfileManager;
        public DeletePoolLogic(ConfigManager configManager, CurrencyManager currencyManager, PoolManager poolManager, UserProfileManager userProfileManager) : base("Delete Pool")
        {
            _configManager = configManager;
            _currencyManager = currencyManager;
            _poolManager = poolManager;
            _userProfileManager = userProfileManager;
        }

        public string DeletePoolProcess(SocketInteractionContext context, string poolIdOne, string poolIdTwo)
        {
            // Check if given Id's match exactly
            if (!poolIdOne.Equals(poolIdTwo))
                return $"The ID's entered did not match. You entered: '{poolIdOne}' - '{poolIdTwo}'";

            // Check if given Id is in database
            if (!_poolManager.IsPoolIdInDatabase(poolIdOne))
                return $"Given pool ID not found in Database: {poolIdOne}";

            // Grab pool
            Pool? pool = _poolManager.GetPoolById(poolIdOne);

            // Check if invoker is owner of pool (or admin)
            if (context.User is not SocketGuildUser guildUser)
                return "This command must be used in a guild.";
            bool IsAdmin = guildUser.GuildPermissions.Administrator;
            if (!_poolManager.IsUserPoolOwner(context.User.Id, pool) && !_configManager.IsDeputyAdmin(context.User.Id) && !IsAdmin)
                return $"You are not the owner of {pool.Id}, nor do you have Guild or Deputy Admin permissions... {pool.OwnerDisplayName} is the owner.";

            // Refund all wagers, if any
            if (pool.Wagers.Count > 0)
                foreach (Wager wager in pool.Wagers)
                    if (_userProfileManager.IsUserRegistered(wager.DiscordId))
                        _currencyManager.AddAmountToUserMainCurrency(_userProfileManager.GetUserProfile(wager.DiscordId), wager.Amount);

            _poolManager.RemovePool(pool);
            _userProfileManager.SaveAndReloadUserProfileList();

            return $"**{pool.Id}** has been deleted from the database. Any pending wagers have been refunded to the user.";
        }
    }
}
