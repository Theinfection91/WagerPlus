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
    public class RequireCurrencySetupAttribute : PreconditionAttribute
    {
        public override async Task<PreconditionResult> CheckRequirementsAsync(IInteractionContext context, ICommandInfo commandInfo, IServiceProvider services)
        {
            ConfigManager? configManager = services.GetService(typeof(ConfigManager)) as ConfigManager;

            if (configManager == null)
            {
                await context.Interaction.RespondAsync("⚠️ **Error:** Unable to retrieve configuration settings.", ephemeral: true);
                return PreconditionResult.FromError("Unable to grab ConfigManager from service binder for DI.");
            }

            if (!configManager.GetIsCurrencySetupComplete())
            {
                await context.Interaction.RespondAsync("⚠️ **Error:** Currency setup is not complete. An admin must set this up using `/setup currency`.", ephemeral: true);
                return PreconditionResult.FromError("Currency setup is not complete.");
            }

            return PreconditionResult.FromSuccess();
        }
    }
}
