using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Core.Enums;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class LockTargetsLogic : Logic
    {
        private PoolManager _poolManager;

        public LockTargetsLogic(PoolManager poolManager) : base("Add Pool Choice")
        {
            _poolManager = poolManager;
        }

        public string LockTargetsProcess(SocketInteractionContext context, string poolId)
        {
            // Grab Pool from database if it exists
            if (_poolManager.IsPoolIdInDatabase(poolId))
            {
                Pool? pool = _poolManager.GetPoolById(poolId);

                // Make sure both targets are added
                if (pool.IsTargetsFull())
                {
                    // Compare the odds between two teams, they can not be the same
                    if (pool.IsOddsDifferent())
                    {
                        // Check if targets are locked already
                        if (!pool.IsTargetsLocked)
                        {
                            // Lock target bool
                            _poolManager.SetTargetsLocked(pool, true);

                            // Save and reload Pools Database
                            _poolManager.SaveAndReloadBettingPoolsDatabase();

                            return $"Targets have been locked for {pool.Name} successfully.";
                        }
                        return $"Targets have already been locked.";
                    }
                    return $"The odds for both targets are set to **{pool.TargetOneOdds}**. Please change one using `/pool set_odds`";
                }
                return $"Incorrect amount of targets in the given pool. Must have two targets, pool currently has: {pool.Targets.Count}";
            }
            return $"The pool Id given was not found in the database: {poolId}";
        }
    }
}
