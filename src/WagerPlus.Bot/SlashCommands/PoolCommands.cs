using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
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
        private AddTargetLogic _addTargetCommand;

        public PoolCommands(CreatePoolLogic createPoolCommand, GenerateChoicesLogic addChoiceCommand, AddTargetLogic addTarget)
        {
            _createPoolCommand = createPoolCommand;
            _generateChoicesCommand = addChoiceCommand;
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

        [RequireUserRegistered]
        [SlashCommand("generate_choices", "Generate choices to wager on when a pool has two targets.")]
        public async Task AddChoice(string poolName, string? description = null)
        {
            var result = _generateChoicesCommand.GenerateChoicesProcess(Context, poolName, description);
            await RespondAsync(result);
        }

        [SlashCommand("add_target", "Add a choice to wager on in given pool.")]
        public async Task AddTarget(string poolName, string name, string? description = null)
        {
            var result = _addTargetCommand.AddTargetProcess(Context, poolName, name, description);
            await RespondAsync(result);
        }
    }
}
