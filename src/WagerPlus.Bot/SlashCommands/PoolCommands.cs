using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Core.Enums;

namespace WagerPlus.Bot.SlashCommands
{
    public class PoolCommands : InteractionModuleBase<SocketInteractionContext>
    {


        public PoolCommands()
        {

        }

        [SlashCommand("create", "Create a new betting pool by specified type")]
        public async Task CreatePoolAsync(SocketInteractionContext context, string name, PoolType poolType, string? description = null)
        {

        }
    }
}
