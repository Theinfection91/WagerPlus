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
    public class RequireUserRegisteredAttribute : PreconditionAttribute
    {
        public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
        {
            UserProfileManager? userProfileManager = services.GetService(typeof(UserProfileManager)) as UserProfileManager;

            if (userProfileManager == null)
            {
                await context.Interaction.RespondAsync("⚠️ **Error:** Unable to retrieve UserProfileManager.", ephemeral: true);
                return PreconditionResult.FromError("Unable to grab UserProfileManager from service binder for DI.");
            }

            if (!userProfileManager.IsUserRegistered(context.User.Id))
            {
                await context.Interaction.RespondAsync("⚠️ **Error:** You are not registered to the database yet. Please use `/setup register_user` to begin.", ephemeral: true);
                return PreconditionResult.FromError($"{context.User.Username} ({context.User.Id}) is not registered in the database.");
            }

            return PreconditionResult.FromSuccess();
        }
    }
}
