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

        public string AddTargetProcess(SocketInteractionContext context, string poolName, string name, string? description = null)
        {
            // Check if Pool exists
            if (!_poolManager.IsPoolNameUnique(poolName))
            {
                // Grab pool
                Pool? pool = _poolManager.GetPoolByName(poolName);

                // Check if pool has room for another target
                if (pool?.Targets.Count < 2)
                {
                    // Check if target name is unique
                    if (_poolManager.IsTargetNameUnique(poolName, name))
                    {
                        // Assign correct choice enum
                        PoolTarget poolTarget = _poolManager.GetCorrectTargetEnum(pool);

                        // Create the target
                        Target target = new(name, poolTarget, description);
                        pool?.AddTargetToDictionary(target);

                        // Save and reload Pools
                        _poolManager.SaveAndReloadBettingsPoolDatabase();

                        return $"{target.Name} was added to {pool?.Name} as Target #{pool?.Targets.FirstOrDefault(x => x.Value == target).Key}";
                    }
                    return $"The given target name already exists in the given pool name... Given target name: {name} - Given pool name: {poolName}";
                }
                return $"This type of pool currently has the maximum amount of targets: {pool?.Targets.Count}";                
            }
            return $"The pool name given was not found in the database: {poolName}";
        }
    }
}
