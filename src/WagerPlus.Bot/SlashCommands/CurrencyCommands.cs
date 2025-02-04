using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.CurrencyCommands;
using WagerPlus.CommandLogic.PoolCommands;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models.Pools;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("currency", "Currency related commands like setup, award, etc.")]
    public class CurrencyCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private ClaimDailyRewardLogic _claimDailyRewardLogic;
        public CurrencyCommands(ClaimDailyRewardLogic claimDailyRewardLogic)
        {
            _claimDailyRewardLogic = claimDailyRewardLogic;
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

        [SlashCommand("claim_daily_reward", "Claim your daily currency with this command.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task ClaimDailyRewardAsync()
        {
            var result = _claimDailyRewardLogic.ClaimDailyRewardProcess(Context);
            await RespondAsync(result, ephemeral: true);
        }
    }
}
