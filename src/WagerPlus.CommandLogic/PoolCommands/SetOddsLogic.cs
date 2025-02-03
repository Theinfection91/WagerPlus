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
    public class SetOddsLogic : Logic
    {
        private ConfigManager _configManager;
        private PoolManager _poolManager;
        public SetOddsLogic(ConfigManager configManager, PoolManager poolManager) : base("Edit Pool Odds")
        {
            _configManager = configManager;
            _poolManager = poolManager;
        }

        public string SetOddsProcess(SocketInteractionContext context, string poolId, PoolTarget target, decimal odds)
        {
            // Check for usable odds amount
            if (!_poolManager.IsOddsAmountValid(odds))
                return $"Odds must be 1.01 or higher to ensure profit.";

            // Check if pool by given Id exists
            if (!_poolManager.IsPoolIdInDatabase(poolId))
                return $"No pool found by the ID of **{poolId}**";

            // Grab pool
            Pool? pool = _poolManager.GetPoolById(poolId);

            // Check if invoker is owner of pool (or admin)
            if (context.User is not SocketGuildUser guildUser)
                return "This command must be used in a guild.";
            bool IsAdmin = guildUser.GuildPermissions.Administrator;
            if (!_poolManager.IsUserPoolOwner(context.User.Id, pool) && !_configManager.IsDeputyAdmin(context.User.Id) && !IsAdmin)
                return $"You are not the owner of {pool.Id}, nor do you have Guild or Deputy Admin permissions... {pool.OwnerDisplayName} is the owner.";

            // Check if targets are set
            if (!pool.IsTargetsFull())
                return $"Both targets must be set to use this command. Initial odds are set when you add a target, this command is to help edit odds in case you entered one wrong in that command.";

            // Check if pool is closed, cant change odds when its open
            if (_poolManager.IsPoolOpen(pool))
                return $"The pool is currently open. Cannot change odds after a pool has opened.";

            // Edit specified targets odds and save/reload
            pool.EditChoiceOddsAmount(target, odds);
            _poolManager.SaveAndReloadBettingPoolsDatabase();
            return $"{target}'s odds have been set to **{odds}**";
        }
    }
}
