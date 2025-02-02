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
    public class ResolvePoolLogic : Logic
    {
        private CurrencyManager _currencyManager;
        private PoolManager _poolManager;
        private UserProfileManager _userProfileManager;
        private WagerManager _wagerManager;

        public ResolvePoolLogic(CurrencyManager currencyManager, PoolManager poolManager, UserProfileManager userProfileManager, WagerManager wagerManager) : base("Resolve Pool")
        {
            _currencyManager = currencyManager;
            _poolManager = poolManager;
            _userProfileManager = userProfileManager;
            _wagerManager = wagerManager;
        }

        public string ResolvePoolProcess(SocketInteractionContext context, string poolIdOne, string poolIdTwo)
        {
            // Check if given Id's match exactly
            if (!poolIdOne.Equals(poolIdTwo))
                return $"The ID's entered did not match. Make sure the P is capital as well. You entered: '{poolIdOne}' - '{poolIdTwo}'";

            // Check if given Id is in database
            if (!_poolManager.IsPoolIdInDatabase(poolIdOne))
                return $"Given pool ID not found in Database: {poolIdOne}";

            // Grab pool
            Pool? pool = _poolManager.GetPoolById(poolIdOne);

            // Check if invoker is owner of pool (or admin)
            if (context.User is not SocketGuildUser guildUser)
                return "This command must be used in a guild.";
            bool IsAdmin = guildUser.GuildPermissions.Administrator;
            if (!_poolManager.IsUserPoolOwner(context.User.Id, pool) || !IsAdmin)
                return $"You are not the owner of {pool.Id}, nor do you have admin permissions... {pool.OwnerDisplayName} is the owner.";

            // Check current status
            if (_poolManager.IsPoolOpen(pool) && pool.Status != PoolStatus.Resolved)
                return "The pool is open. Close it before resolving.";

            // Check if winner has been set
            if (!pool.IsWinningTargetSet)
                return $"A winner has not been submitted to **{pool.Id}** - Submit a winning target with `/pool submit_winner`";

            // Award currency to winners based on WinningTarget
            foreach (var wager in pool.Wagers)
            {
                if (wager.Target.Equals(pool.WinningTarget))
                {
                    // Grab user profile
                    UserProfile? userProfile = _userProfileManager.GetUserProfile(wager.DiscordId);
                    if (userProfile != null)
                    {
                        int payoutTotal = _wagerManager.GetWagerPayoutTotal(wager);
                        _currencyManager.AddAmountToUserCurrency(userProfile, payoutTotal);
                    }
                }
            }
            // Clear all wagers in pool
            pool.ClearWagers();

            // Change status and time stamp
            _poolManager.SetPoolStatus(pool, PoolStatus.Resolved);

            // Save appropriate databases
            _poolManager.SaveAndReloadBettingPoolsDatabase();
            _userProfileManager.SaveAndReloadUserProfileList();

            return $"The pool has been resolved, and winning wagers have been awarded to winners. You can now remove it safely.";
        }
    }
}
