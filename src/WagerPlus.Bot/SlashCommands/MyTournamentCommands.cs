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
        private MyTournamentRegisterLogic _myTournamentBeginLogic;
        public MyTournamentCommands(MyTournamentRegisterLogic myTournamentBeginLogic)
        {
            _myTournamentBeginLogic = myTournamentBeginLogic;
        }

        [SlashCommand("register", "Start the onboarding process of MyTournament.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task MyTournamentRegisterAsync()
        {

        }

        [SlashCommand("hub", "Show all pertinent information about your tournament.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        [RequireMyTournamentRegistered]
        public async Task MyTournamentHubAsync()
        {

        }
    }
}
