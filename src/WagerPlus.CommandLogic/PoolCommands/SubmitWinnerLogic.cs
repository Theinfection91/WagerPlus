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
    public class SubmitWinnerLogic : Logic
    {
        private PoolManager _poolManager;
        public SubmitWinnerLogic(PoolManager poolManager) : base("Submit Winner")
        {
            _poolManager = poolManager;
        }

        public string SubmitWinnerProcess(SocketInteractionContext context, string poolId, PoolTarget poolTarget)
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
            if (!_poolManager.IsUserPoolOwner(context.User.Id, pool) || !IsAdmin)
                return $"You are not the owner of {pool.Id}, nor do you have admin permissions... {pool.OwnerDisplayName} is the owner.";

            // Check current status
            if (_poolManager.IsPoolOpen(pool))
                return $"A pool must be closed before it can have a winner submitted.";

            // Check if pool has been opened before
            if (pool.IsFresh.Equals(true))
                return "This pool has never been opened for wagers before. Can not set a winner.";

            pool.WinningTarget = poolTarget;
            pool.IsWinningTargetSet = true;

            _poolManager.SaveAndReloadBettingPoolsDatabase();

            return $"The winner of **({pool.Id}) {pool.Name}** has been set to **{pool.GetNameForTarget(poolTarget)}**. You may now use `/pool resolve` to award payouts and clear wagers. If the wrong target was submitted as the winner then use this command again to choose the correct target before using the `/pool resolve` command.";
        }
    }
}
