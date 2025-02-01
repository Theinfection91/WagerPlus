using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.CurrencyCommands;
using WagerPlus.CommandLogic.RegisterUserCommands;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("currency", "Currency related commands like setup, award, etc.")]
    public class CurrencyCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public CurrencyCommands()
        {

        }
    }
}
