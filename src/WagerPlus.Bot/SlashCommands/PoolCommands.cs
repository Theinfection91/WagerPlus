using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.CommandLogic.PoolCommands;
using WagerPlus.Core.Enums;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("pool", "Pool related commands like creating, adding choices, open/close/resolve")]
    public class PoolCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private CreatePool _createPoolCommand;
        private AddChoice _addChoiceCommand;

        public PoolCommands(CreatePool createPoolCommand, AddChoice addChoiceCommand)
        {
            _createPoolCommand = createPoolCommand;
            _addChoiceCommand = addChoiceCommand;
        }

        [SlashCommand("create", "Create a new betting pool of specified type")]
        public async Task CreatePoolAsync(string name, PoolType poolType, string? description = null)
        {
            var result = _createPoolCommand.CreatePoolLogic(Context, name, poolType, description);
            await RespondAsync(result);
        }

        [SlashCommand("add_choice", "Add a choice to wager on in given pool")]
        public async Task AddChoice(string title, string target, WagerCondition condition, string? description = null)
        {
            var result = _addChoiceCommand.AddChoiceLogic(Context, title, target, condition, description);
            await RespondAsync(result);
        }
    }
}
