using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Managers;

namespace WagerPlus.Bot.PreconditionAttributes
{
    public class RequireMyTournamentRegisteredAttribute : PreconditionAttribute
    {
        public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
        {
            MyTournamentManager? myTournamentManager = services.GetService(typeof (MyTournamentManager)) as MyTournamentManager;

            if (myTournamentManager == null)
            {
                await context.Interaction.RespondAsync("⚠️ **Error:** Unable to retrieve MyTournamentManager.", ephemeral: true);
                return PreconditionResult.FromError("Unable to grab MyTournamentManager from service binder for DI.");
            }

            if (!myTournamentManager.IsUserRegistered(context.User.Id))
            {
                await context.Interaction.RespondAsync("⚠️ **Error:** You are do not have a tournament registered to you yet. Please use `/my_tournament register` to begin.", ephemeral: true);
                return PreconditionResult.FromError($"{context.User.Username} ({context.User.Id}) is not registered in the database.");
            }

            return PreconditionResult.FromSuccess();
        }
    }
}
