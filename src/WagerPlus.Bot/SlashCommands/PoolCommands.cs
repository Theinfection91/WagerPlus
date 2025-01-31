﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Bot.Modals.PoolModals;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.PoolCommands;
using WagerPlus.Core.Enums;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("pool", "Pool related commands like creating, adding choices, open/close/resolve.")]
    public class PoolCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private CreatePoolLogic _createPoolCommand;
        private GenerateChoicesLogic _generateChoicesCommand;
        private SetOddsLogic _setOddsLogic;
        private AddTargetLogic _addTargetCommand;

        public PoolCommands(CreatePoolLogic createPoolCommand, GenerateChoicesLogic addChoiceCommand, SetOddsLogic editOddsLogic, AddTargetLogic addTarget)
        {
            _createPoolCommand = createPoolCommand;
            _generateChoicesCommand = addChoiceCommand;
            _setOddsLogic = editOddsLogic;
            _addTargetCommand = addTarget;
        }

        [SlashCommand("create", "Create a new betting pool of specified type.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task CreatePoolAsync(string name, PoolType poolType, string? description = null)
        {
            try
            {
                var result = _createPoolCommand.CreatePoolProcess(Context, name, poolType, description);
                await RespondAsync(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Command Error: {ex}");
                await RespondAsync("An error occurred while processing this command.", ephemeral: true);
            }
        }

        
        [SlashCommand("generate_choices", "Generate choices to wager on when a pool has two targets.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task GenerateChoicesAsync(string poolId, string? description = null)
        {
            var result = _generateChoicesCommand.GenerateChoicesProcess(Context, poolId, description);
            await RespondAsync(result);
        }

        [SlashCommand("add_target", "Add a target for a choice in given pool.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task AddTargetAsync(string poolId, string name, string? description = null)
        {
            var result = _addTargetCommand.AddTargetProcess(Context, poolId, name, description);
            await RespondAsync(result);
        }

        [SlashCommand("set_odds", "Edits the odds for a choice in given pool before it opens.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task SetOddsAsync(string poolId, PoolChoice choice, decimal odds)
        {
            var result = _setOddsLogic.SetOddsProcess(Context, poolId, choice, odds);
            await RespondAsync(result);
        }

        [SlashCommand("open", "Set the pool status of given Pool to Open, allowing wagers.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task OpenPoolAsync()
        {
            await RespondWithModalAsync<OpenPoolModal>("open_pool");
        }

    }
}
