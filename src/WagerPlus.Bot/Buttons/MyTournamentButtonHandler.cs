using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;

namespace WagerPlus.Bot.Buttons
{
    public class MyTournamentButtonHandler : InteractionModuleBase<SocketInteractionContext>
    {
        public MessageComponent GetHiringPoolButtons()
        {
            var builder = new ComponentBuilder()
                .WithButton("Hire Candidate 1", "hire_candidate_1", ButtonStyle.Primary)
                .WithButton("Hire Candidate 2", "hire_candidate_2", ButtonStyle.Primary)
                .WithButton("Hire Candidate 3", "hire_candidate_3", ButtonStyle.Primary)
                .WithButton("Cancel", "cancel_hiring", ButtonStyle.Danger);

            return builder.Build();
        }

        [ComponentInteraction("hire_candidate_*")]
        public async Task HandleHiring(string candidateId)
        {
            await RespondAsync("Test");
        }

        [ComponentInteraction("cancel_hiring")]
        public async Task HandleCancelHiring()
        {
            await RespondAsync("Cancel");
        }
    }
}
