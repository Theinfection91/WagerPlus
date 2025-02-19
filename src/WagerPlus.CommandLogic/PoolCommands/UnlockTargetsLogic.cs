﻿using System;
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
    public class UnlockTargetsLogic : Logic
    {
        private ConfigManager _configManager;
        private PoolManager _poolManager;

        public UnlockTargetsLogic(ConfigManager configManager, PoolManager poolManager) : base("Unlock Targets")
        {
            _configManager = configManager;
            _poolManager = poolManager;
        }

        public string UnlockTargetsProcess(SocketInteractionContext context, string poolId)
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
            if (!pool.IsFresh)
                return $"The pool has already been opened for wagers once with locked targets. Can not unlock targets after opening a pool.";

            if (_poolManager.IsPoolOpen(pool))
                return $"The pool is already open.";

            if (pool.Status == PoolStatus.Resolved)
                return $"That pool has already been resolved.";

            // Check if targets are locked
            if (!pool.IsTargetsLocked)
                return $"Targets have not been locked yet.";

            // Unlock targets in pool
            _poolManager.SetTargetsLocked(pool, false);

            // Save and reload Pools Database
            _poolManager.SaveAndReloadBettingPoolsDatabase();
            return $"Targets have been unlocked for {pool.Id} successfully.";
        }
    }
}
