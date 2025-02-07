using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.Core.Enums.InvestEnums;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("fun", "Minigame, invest, and fun related optional commands.")]
    public class FunCommands : InteractionModuleBase<SocketInteractionContext>
    {
        public FunCommands()
        {

        }
        [Group("invest", "Invest commands like using a bank or investing in a tournament.")]
        public class InvestCommands : InteractionModuleBase<SocketInteractionContext>
        {
            public InvestCommands()
            {

            }

            [SlashCommand("bank", "Invest earnings in a bank for a certain amount of time.")]
            [RequireCurrencySetup]
            [RequireUserRegistered]
            public async Task InvestBankAsync(
                [Summary("amount", "The amount to invest.")] int amount,
                [Summary("invest_time", "The amount of time to invest.")] InvestTime investTime)
            {

            }
        }

        [Group("my_tournament", "Invest in your own mini RNG tournaments.")]
        public class MyTournamentCommands : InteractionModuleBase<SocketInteractionContext>
        {
            public MyTournamentCommands()
            {

            }

            [SlashCommand("begin", "Start the onboarding process of MyTournament.")]
            [RequireCurrencySetup]
            [RequireUserRegistered]
            public async Task MyTournamentBeginAsync()
            {

            }
        }
    }
}
