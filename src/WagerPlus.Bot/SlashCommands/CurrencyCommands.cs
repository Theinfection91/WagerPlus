using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.CommandLogic.CurrencyCommands;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("currency", "Currency related commands like setup, award, etc.")]
    public class CurrencyCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private SetupCurrencyLogic _setupCurrencyLogic;
        public CurrencyCommands(SetupCurrencyLogic setupCurrencyLogic)
        {
            _setupCurrencyLogic = setupCurrencyLogic;
        }

        [SlashCommand("setup", "Admin command to setup the initial currency info for bot")]
        public async Task SetupCurrencyAsync(string currencyName, string currencyAbbreviation)
        {
            var result = _setupCurrencyLogic.SetupCurrencyProcess(currencyName, currencyAbbreviation);
            await RespondAsync(result);
        }
    }
}
