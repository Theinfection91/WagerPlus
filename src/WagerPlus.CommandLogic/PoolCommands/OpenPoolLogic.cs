using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using Discord.WebSocket;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class OpenPoolLogic : Logic
    {
        private PoolManager _poolManager;
        public OpenPoolLogic(PoolManager poolManager) : base("Open Pool")
        {
            _poolManager = poolManager;
        }

        public string OpenPoolProcess(SocketInteractionContext context, string poolIdOne, string poolIdTwo)
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

            // Check if targets were set
            if (!_poolManager.IsBothTargetsSetInPool(pool))
                return $"There are not enough targets in {pool.Id}";

            // Check if targets are locked
            if (!_poolManager.IsTargetsLocked(pool))
                return $"Targets have not been locked for {pool.Id}";

            // Check if open already
            if (_poolManager.IsPoolOpen(pool))
                return $"The pool is already Open.";

            // Check if pool has been opened before
            if (!pool.IsFresh)
                return $"Pool has already been opened for wagers once. Cannot open again.";

            // Change statuses and save/reload
            _poolManager.SetPoolStatus(pool, PoolStatus.Open);
            pool.IsFresh = false;
            _poolManager.SaveAndReloadBettingPoolsDatabase();

            return $"{pool.Id} is now {pool.Status} for wagers!";
        }
    }
}
