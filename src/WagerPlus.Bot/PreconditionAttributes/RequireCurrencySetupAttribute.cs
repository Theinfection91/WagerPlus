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
            try
            {
                ConfigManager? configManager = services.GetService(typeof(ConfigManager)) as ConfigManager;

                if (configManager == null)
                {
                    await context.Interaction.RespondAsync("⚠️ **Error:** Unable to retrieve configuration settings.", ephemeral: true);
                    return PreconditionResult.FromError("Unable to grab ConfigManager from service binder for DI.");
                }

                if (!configManager.GetIsCurrencySetupComplete())
                {
                    await context.Interaction.RespondAsync("⚠️ **Error:** Currency setup is not complete. An admin must set this up using `/currency set_up`.", ephemeral: true);
                    return PreconditionResult.FromError("Currency setup is not complete.");
                }

                return PreconditionResult.FromSuccess();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Unexpected Error: {ex}");
                await context.Interaction.RespondAsync("⚠️ **An unexpected error occurred.** Please try again later.", ephemeral: true);
                return PreconditionResult.FromError($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}
