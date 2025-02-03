using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using WagerPlus.Core.Enums;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class LockTargetsLogic : Logic
    {
        private ConfigManager _configManager;
        private PoolManager _poolManager;

        public LockTargetsLogic(ConfigManager configManager, PoolManager poolManager) : base("Add Pool Choice")
        {
            _configManager = configManager;
            _poolManager = poolManager;
        }

        public string LockTargetsProcess(SocketInteractionContext context, string poolId)
        {
            // Check if ID exists
            if (!_poolManager.IsPoolIdInDatabase(poolId))
                return $"The pool Id given was not found in the database: {poolId}";

            // Grab pool
            Pool? pool = _poolManager.GetPoolById(poolId);

            // Check if invoker is owner of pool (or admin)
            if (context.User is not SocketGuildUser guildUser)
                return "This command must be used in a guild.";
            bool IsAdmin = guildUser.GuildPermissions.Administrator;
            if (!_poolManager.IsUserPoolOwner(context.User.Id, pool) && !_configManager.IsDeputyAdmin(context.User.Id) && !IsAdmin)
                return $"You are not the owner of {pool.Id}, nor do you have Guild or Deputy Admin permissions... {pool.OwnerDisplayName} is the owner.";

            // Check status
            if (_poolManager.IsPoolOpen(pool))
                return $"The pool is already open.";

            if (pool.Status == PoolStatus.Resolved)
                return $"That pool has already been resolved.";

            // Check if there are two targets
            if (!pool.IsTargetsFull())
                return $"Incorrect amount of targets in the given pool. Must have two targets.";

            // Compare the odds between two teams, they can not be the same
            if (!pool.IsOddsDifferent())
                return $"The odds for both targets are set to **{pool.TargetOneOdds}**. Please change one using `/pool set_odds`";

            // Check if targets are locked already
            if (pool.IsTargetsLocked)
                return $"Targets have already been locked.";

            // Lock targets in pool
            _poolManager.SetTargetsLocked(pool, true);

            // Save and reload Pools Database
            _poolManager.SaveAndReloadBettingPoolsDatabase();
            return $"Targets have been locked for {pool.Id} successfully.";
        }
    }
}
