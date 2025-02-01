using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.CurrencyCommands;
using WagerPlus.CommandLogic.RegisterUserCommands;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("setup", "Commands for setting up currency, user profiles and more.")]
    public class SetupCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private RegisterUserLogic _registerUserLogic;
        private SetupCurrencyLogic _setupCurrencyLogic;
        public SetupCommands(RegisterUserLogic registerUserLogic, SetupCurrencyLogic setupCurrencyLogic)
        {
            _registerUserLogic = registerUserLogic;
            _setupCurrencyLogic = setupCurrencyLogic;
        }

        [RequireCurrencySetup]
        [SlashCommand("register_user", "The first command all users must run to begin.")]
        public async Task RegisterUserAsync()
        {
            var result = _registerUserLogic.RegisterUserProcess(Context);
            await RespondAsync(result);
        }

        [SlashCommand("currency", "Admin command to setup the initial currency info for bot")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        public async Task SetupCurrencyAsync(
            [Summary("currency_name", "The full name of your new currency")] string currencyName,
            [Summary("currency_abbrev", "The abbreviation for it (Ex. SB, $Ix, BUX")] string currencyAbbreviation)
        {
            var result = _setupCurrencyLogic.SetupCurrencyProcess(currencyName, currencyAbbreviation);
            await RespondAsync(result);
        }
    }
}
