using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.WagerCommands;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("wager", "Wager related commands like creating, or checking active wagers.")]
    public class WagerCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private CreateWagerLogic _createWagerLogic;
        private MinimumWagerLogic _minimumWagerLogic;
        private SimulateWagerLogic _simulateWagerLogic;

        public WagerCommands(CreateWagerLogic createWagerLogic, MinimumWagerLogic minimumWagerLogic, SimulateWagerLogic simulateWagerLogic)
        {
            _createWagerLogic = createWagerLogic;
            _minimumWagerLogic = minimumWagerLogic;
            _simulateWagerLogic = simulateWagerLogic;
        }

        [SlashCommand("create", "Creates a wager in the given pool")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task CreateWagerAsync(string poolName, PoolChoice choice, int amount)
        {
            var result = _createWagerLogic.CreateWagerProcess(Context, poolName, choice, amount);
            await RespondAsync(result);
        }

        [SlashCommand("minimum", "Returns the minimum amount needed to make a profit on given choice in given pool")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task MinimumWagerAsync(string poolName, PoolChoice choice)
        {
            var result = _minimumWagerLogic.MinimumWagerProcess(poolName, choice);
            await RespondAsync(result);
        }

        [SlashCommand("simulate", "Returns the value of winning a mock wager")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task SimulateWagerAsync(string poolName, PoolChoice choice, int amount)
        {
            var result = _simulateWagerLogic.SimulateWagerProcess(poolName, choice, amount);
            await RespondAsync(result);
        }
    }
}
