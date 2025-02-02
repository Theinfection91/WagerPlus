using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class SetOddsLogic : Logic
    {
        private PoolManager _poolManager;
        public SetOddsLogic(PoolManager poolManager) : base("Edit Pool Odds")
        {
            _poolManager = poolManager;
        }

        public string SetOddsProcess(SocketInteractionContext context, string poolId, PoolTarget target, decimal odds)
        {
            if (odds < 1.01m)
            {
                return $"Odds can not dip below 1.01";
            }
            // Check if pool by given Id exists
            if (_poolManager.IsPoolIdInDatabase(poolId))
            {
                // Grab pool
                Pool? pool = _poolManager.GetPoolById(poolId);

                // Check if invoker is pool owner
                if (_poolManager.IsUserPoolOwner(context.User.Id, pool))
                {
                    // Check if targets are set
                    if (pool.IsTargetsFull())
                    {
                        // Check if pool is closed, cant change odds when its open
                        if (pool.Status.Equals(PoolStatus.Closed))
                        {
                            pool.EditChoiceOddsAmount(target, odds);
                            _poolManager.SaveAndReloadBettingPoolsDatabase();
                            return $"{target}'s odds have been set to **{odds}**";
                        }
                        return $"The pool is currently open or has been resolved.";
                    }
                    return $"Both targets must be set to use this command. Initial odds are set when you add a target, this command is to help edit odds in case you entered one wrong in that command.";
                }
                return $"You are not the owner of that pool.";
            }
            return $"No pool found by the ID of **{poolId}**";
        }
    }
}
