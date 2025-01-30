using System;
using System.Collections.Generic;
using System.Linq;
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
    public class GenerateChoicesLogic : Logic
    {
        private PoolManager _poolManager;

        public GenerateChoicesLogic(PoolManager poolManager) : base ("Add Pool Choice")
        {
            _poolManager = poolManager;
        }

        public string GenerateChoicesProcess(SocketInteractionContext context, string poolName, string? description = null)
        {
            // Grab Pool from database if it exists
            if (!_poolManager.IsPoolNameUnique(poolName))
            {
                Pool? pool = _poolManager.GetPoolByName(poolName);

                if (pool.Choices.Count != 2 && pool.Choices.Count != 1)
                {

                    // Max sure pool has both targets registered
                    if (pool.Targets.Count == 2)
                    {
                        // Create win choices for each target
                        (Choice, Choice) choices = _poolManager.GetCorrectChoices(pool);

                        // Add choices to Pool
                        pool?.AddChoiceToDictionary(choices.Item1);
                        pool?.AddChoiceToDictionary(choices.Item2);

                        // Save and reload Pools Database
                        _poolManager.SaveAndReloadBettingPoolsDatabase();

                        return $"Choices have been generated for {pool.Name} successfully.";
                    }
                    return $"Incorrect amount of targets in the given pool. Must have two targets, pool currently has: {pool.Targets.Count}";
                }
                return $"There are already enough choices for the given betting pool: {pool.Choices.Count}";
            }            
            return $"The pool name given was not found in the database: {poolName}";
        }
    }
}
