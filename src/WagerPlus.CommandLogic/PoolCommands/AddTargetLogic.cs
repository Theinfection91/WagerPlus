using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class AddTargetLogic : Logic
    {
        private PoolManager _poolManager;

        public AddTargetLogic(PoolManager poolManager) : base("Add Pool Target")
        {
            _poolManager = poolManager;
        }

        public string AddTargetProcess(SocketInteractionContext context, string poolId, string name, string? description = null)
        {
            // Check if Pool exists
            if (_poolManager.IsPoolIdInDatabase(poolId))
            {
                // Grab pool
                Pool? pool = _poolManager.GetPoolById(poolId);

                // Check if pool has room for another target
                if (pool.IsTargetsFull())
                {
                    // Check if target name is unique
                    if (_poolManager.IsTargetNameUnique(poolId, name))
                    {
                        // Assign correct choice enum
                        PoolTarget poolTarget = _poolManager.GetCorrectTargetEnum(pool);

                        // Create the target
                        Target target = new(name, poolTarget, description);
                        pool?.AddTargetToDictionary(target);

                        // Save and reload Pools
                        _poolManager.SaveAndReloadBettingPoolsDatabase();

                        return $"{target.Name} was added to {pool?.Name} as Target #{pool?.Targets.FirstOrDefault(x => x.Value == target).Key}";
                    }
                    return $"The given target name already exists in the given pool Id... Given target name: {name} - Given pool Id: {poolId}";
                }
                return $"This type of pool currently has the maximum amount of targets: {pool?.Targets.Count}";                
            }
            return $"The pool Id given was not found in the database: {poolId}";
        }
    }
}
