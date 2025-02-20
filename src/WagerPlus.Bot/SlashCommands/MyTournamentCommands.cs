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
        private MyTournamentRegisterLogic _myTournamentRegisterLogic;
        public MyTournamentCommands(MyTournamentRegisterLogic myTournamentBeginLogic)
        {
            _myTournamentRegisterLogic = myTournamentBeginLogic;
        }

        [SlashCommand("register", "Start the onboarding process of MyTournament.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task MyTournamentRegisterAsync()
        {
            var result = _myTournamentRegisterLogic.MyTournamentRegisterProcess(Context);
            await RespondAsync(result, ephemeral: true);
        }

        [SlashCommand("hub", "Show all pertinent information about your tournament.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        [RequireMyTournamentRegistered]
        public async Task MyTournamentHubAsync()
        {
            var result = "Yup";
            await RespondAsync(result, ephemeral: true);
        }
    }
}
