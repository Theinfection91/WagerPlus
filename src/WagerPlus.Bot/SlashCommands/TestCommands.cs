using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.CommandLogic;
using WagerPlus.CommandLogic.TestCommands;
using WagerPlus.Core.Models;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("test", "Test slash commands and modals")]
    public class TestCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private Ping _pingCommand;

        public TestCommands(Ping pingCommand)
        {
            _pingCommand = pingCommand;
        }

        [SlashCommand("ping", "Test ping command")]
        public async Task PingAsync()
        {
            var result = _pingCommand.PingLogic();
            await RespondAsync(result);
        }
    }
}
