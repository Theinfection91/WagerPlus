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
    public class ClosePoolLogic : Logic
    {
        private ConfigManager _configManager;
        private PoolManager _poolManager;
        public ClosePoolLogic(ConfigManager configManager, PoolManager poolManager) : base("Close Pool")
        {
            _configManager = configManager;
            _poolManager = poolManager;
        }

        public string ClosePoolProcess(SocketInteractionContext context, string poolIdOne, string poolIdTwo)
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
            if (!_poolManager.IsUserPoolOwner(context.User.Id, pool) && !_configManager.IsDeputyAdmin(context.User.Id) && !IsAdmin)
                return $"You are not the owner of {pool.Id}, nor do you have Guild or Deputy Admin permissions... {pool.OwnerDisplayName} is the owner.";

            // Check if pool is open
            if (!_poolManager.IsPoolOpen(pool))
                return $"The pool is already closed.";

            // Change status
            _poolManager.SetPoolStatus(pool, PoolStatus.Closed);
            _poolManager.SaveAndReloadBettingPoolsDatabase();

            return $"{pool.Id} is now closed for wagers.";
        }
    }
}
