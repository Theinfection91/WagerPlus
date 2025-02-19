﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
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
        private DeleteWagerLogic _deleteWagerLogic;
        private MinimumWagerLogic _minimumWagerLogic;
        private SimulateWagerLogic _simulateWagerLogic;

        public WagerCommands(CreateWagerLogic createWagerLogic, DeleteWagerLogic deleteWagerLogic, MinimumWagerLogic minimumWagerLogic, SimulateWagerLogic simulateWagerLogic)
        {
            _createWagerLogic = createWagerLogic;
            _deleteWagerLogic = deleteWagerLogic;
            _minimumWagerLogic = minimumWagerLogic;
            _simulateWagerLogic = simulateWagerLogic;
        }

        [SlashCommand("create", "Creates a wager in the given pool")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task CreateWagerAsync(
            [Summary("pool_id", "The pool ID to create a wager in")] string poolId,
            [Summary("pool_target", "The choice in the pool to wager on")] PoolTarget target,
            [Summary("wager_amount", "The amount the user is wagering")] int amount)
        {
            var result = _createWagerLogic.CreateWagerProcess(Context, poolId, target, amount);
            await RespondAsync(result);
        }

        [SlashCommand("delete", "Bookie/Admin command to delete wagers in a pool")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task DeleteWagerAsync(
            [Summary("pool_id", "The pool ID to create a wager in")] string poolId,
            [Summary("user", "The user who created the wager.")] IUser user
            )
        {
            var result = _deleteWagerLogic.DeleteWagerProcess(Context, poolId, user.Id);
            await RespondAsync(result);
        }

        [SlashCommand("minimum", "Returns the minimum amount needed to make a profit on given choice in given pool")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task MinimumWagerAsync(
            [Summary("pool_id", "The pool ID to check the minimum in")] string poolId,
            [Summary("pool_target", "The target on which to get the minimum wager for")] PoolTarget target)
        {
            var result = _minimumWagerLogic.MinimumWagerProcess(poolId, target);
            await RespondAsync(result);
        }

        [SlashCommand("simulate", "Returns the value of winning a mock wager")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task SimulateWagerAsync(
            [Summary("pool_id", "The pool ID to simulate wager in")] string poolId,
            [Summary("pool_target", "The target to simulate a wager on")] PoolTarget target,
            [Summary("wager_amount", "The amount to simulate")] int amount)
        {
            var result = _simulateWagerLogic.SimulateWagerProcess(poolId, target, amount);
            await RespondAsync(result);
        }
    }
}
