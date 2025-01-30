using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.CommandLogic.WagerCommands;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("wager", "Wager related commands like creating, or checking active wagers.")]
    public class WagerCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private CreateWagerLogic _createWagerLogic;

        public WagerCommands(CreateWagerLogic createWagerLogic)
        {
            _createWagerLogic = createWagerLogic;
        }

        [SlashCommand("create", "Creates a wager in the given pool")]
        public async Task CreateWagerAsync(string poolName, PoolChoice choice, int amount)
        {
            var result = _createWagerLogic.CreateWagerProcess(Context, poolName, choice, amount);
            await RespondAsync(result);
        }
    }
}
