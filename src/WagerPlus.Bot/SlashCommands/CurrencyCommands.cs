using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Bot.PreconditionAttributes;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("currency", "Currency related commands like setup, award, etc.")]
    public class CurrencyCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public CurrencyCommands()
        {

        }


        [SlashCommand("award_user", "Admin command to award currency amount to given user.")]
        [RequireUserPermission(Discord.GuildPermission.Administrator)]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task AwardUserAsync(
            [Summary("user", "The user to award currency to.")] IUser user,
            [Summary("amount", "The amount to give.")] int amount)
        {

        }
    }
}
