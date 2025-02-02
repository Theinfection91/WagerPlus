using Discord;
using Discord.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.SetupCommands;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("setup", "Commands for setting up currency, user profiles and more.")]
    public class SetupCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private DemonetizeChannelLogic _demonetizeChannelLogic;
        private MonetizeChannelLogic _monetizeChannelLogic;
        private RegisterUserLogic _registerUserLogic;
        private SetupCurrencyLogic _setupCurrencyLogic;
        public SetupCommands(DemonetizeChannelLogic demonetizeChannelLogic, MonetizeChannelLogic monetizeChannelLogic, RegisterUserLogic registerUserLogic, SetupCurrencyLogic setupCurrencyLogic)
        {
            _demonetizeChannelLogic = demonetizeChannelLogic;
            _monetizeChannelLogic = monetizeChannelLogic;
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
            await RespondAsync(result, ephemeral: true);
        }

        [SlashCommand("monetize_channel", "Add channel to Monetized channels list.")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task MonetizeChannelAsync(
            [Summary("channel", "The channel to monetize")] IMessageChannel channel)
        {
            var result = _monetizeChannelLogic.MonetizeChannelProcess(channel.Id);
            await RespondAsync(ephemeral: true, embed: result);
        }

        [SlashCommand("demonetize_channel", "Remove channel from Monetized channels list.")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task DemonetizeChannelAsync(
            [Summary("channel", "The channel to demonetize")] IMessageChannel channel)
        {
            var result = _demonetizeChannelLogic.DemonetizeChannelProcess(channel.Id);
            await RespondAsync(ephemeral: true, embed: result);
        }
    }
}
