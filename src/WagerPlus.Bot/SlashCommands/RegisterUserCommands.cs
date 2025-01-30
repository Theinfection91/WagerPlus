using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.RegisterUserCommands;

namespace WagerPlus.Bot.SlashCommands
{

    public class RegisterUserCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private RegisterUserLogic _registerUserLogic;
        public RegisterUserCommands(RegisterUserLogic registerUserLogic)
        {
            _registerUserLogic = registerUserLogic;
        }

        [RequireCurrencySetup]
        [SlashCommand("register_user", "The first command all users must run to begin.")]
        public async Task RegisterUserAsync()
        {
            var result = _registerUserLogic.RegisterUserProcess(Context);
            await RespondAsync(result);
        }
    }
}
