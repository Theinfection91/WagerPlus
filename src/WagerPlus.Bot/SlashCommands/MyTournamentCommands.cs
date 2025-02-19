using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.FunCommands.MyTournamentCommands;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("my_tournament", "Invest in your own mini RNG tournaments.")]
    public class MyTournamentCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private MyTournamentBeginLogic _myTournamentBeginLogic;
        public MyTournamentCommands(MyTournamentBeginLogic myTournamentBeginLogic)
        {
            _myTournamentBeginLogic = myTournamentBeginLogic;
        }

        [SlashCommand("begin", "Start the onboarding process of MyTournament.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task MyTournamentBeginAsync()
        {

        }
    }
}
