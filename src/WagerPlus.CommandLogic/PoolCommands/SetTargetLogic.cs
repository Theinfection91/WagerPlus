using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class SetTargetLogic : Logic
    {
        private PoolManager _poolManager;

        public SetTargetLogic(PoolManager poolManager) : base("Set Pool Target")
        {
            _poolManager = poolManager;
        }

        public string SetTargetProcess(SocketInteractionContext context, string poolId, PoolTarget targetPosition, string name, decimal odds, string? description = null)
        {
            // Check if Pool exists
            if (!_poolManager.IsPoolIdInDatabase(poolId))
                return $"The pool Id given was not found in the database: {poolId}";

            // If found, grab correct pool
            Pool? pool = _poolManager.GetPoolById(poolId);

            // Check if targets locked
            if (_poolManager.IsTargetsLocked(pool))
                return $"Targets are currently locked in {pool.Id}";

            // Check if target name is unique
            if (!_poolManager.IsTargetNameUnique(poolId, name))
                return $"The given target name already exists in the given pool Id... Given target name: {name} - Given pool Id: {poolId}";

            // Check odds amount
            if (!_poolManager.IsOddsAmountValid(odds))
                return $"Invalids odds amount given. Odds must be **1.01 or higher** to ensure some type of profit on a wager.";

            // Create the target and add to Pool
            Target target = new(name, targetPosition, description);
            pool?.SetTargetToPosition(target);

            // Submit odds amounts to correct target position
            pool.EditChoiceOddsAmount(targetPosition, odds);

            // Save and reload Pools - return message
            _poolManager.SaveAndReloadBettingPoolsDatabase();
            return $"{target.Name} was added to {pool?.Id} as {targetPosition} at **{odds}** Odds!";
        }
    }
}
