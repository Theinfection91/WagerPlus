using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Core.Enums;
using WagerPlus.Core.Models;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class AddChoice : Logic
    {
        private PoolManager _poolManager;

        public AddChoice(PoolManager poolManager) : base ("Add Pool Choice")
        {
            _poolManager = poolManager;
        }

        public string AddChoiceLogic(SocketInteractionContext context, string poolName, string title, string target, WagerCondition condition, string? description = null)
        {
            // Grab Pool from database if it exists
            if (!_poolManager.IsPoolNameUnique(poolName))
            {
                Pool? pool = _poolManager.GetPoolByName(poolName);

                // Create Target and Choice
                Target newTarget = new(target);
                Choice choice = new(title, newTarget, condition, description);

                // Add choice to Pool
                pool.AddChoiceToDictionary(choice);

                // Save and reload Pools Database
                _poolManager.SaveAndReloadBettingsPoolDatabase();
            }            
            return $"The pool name given was not found in the database: {poolName}";
        }
    }
}
