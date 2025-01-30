using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("currency", "Currency related commands like setup, award, etc.")]
    public class CurrencyCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public CurrencyCommands()
        {

        }

        [SlashCommand("setup", "Admin command to setup the initial currency info for bot")]
        public async Task SetupCurrencyAsync(string currencyName, string currencyAbbreviation)
        {

        }
    }
}
