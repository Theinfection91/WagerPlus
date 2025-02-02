using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Bot.Modals.PoolModals;
using WagerPlus.Bot.PreconditionAttributes;
using WagerPlus.CommandLogic.PoolCommands;
using WagerPlus.Core.Enums;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Bot.SlashCommands
{
    [Group("pool", "Pool related commands like creating, adding choices, open/close/resolve.")]
    public class PoolCommands : InteractionModuleBase<SocketInteractionContext>
    {
        private CreatePoolLogic _createPoolLogic;
        private LockTargetsLogic _lockTargetsLogic;
        private UnlockTargetsLogic _unlockTargetsLogic;
        private SetOddsLogic _setOddsLogic;
        private SetTargetLogic _setTargetLogic;
        private SubmitWinnerLogic _submitWinnerLogic;

        public PoolCommands(CreatePoolLogic createPoolLogic, LockTargetsLogic addChoiceLogic, SetOddsLogic editOddsLogic, SetTargetLogic setTargetLogic, SubmitWinnerLogic submitWinnerLogic, UnlockTargetsLogic unlockTargetsLogic)
        {
            _createPoolLogic = createPoolLogic;
            _lockTargetsLogic = addChoiceLogic;
            _unlockTargetsLogic = unlockTargetsLogic;
            _setOddsLogic = editOddsLogic;
            _setTargetLogic = setTargetLogic;
            _submitWinnerLogic = submitWinnerLogic;
        }

        [SlashCommand("create", "Create a new betting pool of specified type.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task CreatePoolAsync(
            [Summary("pool_name", "The new name/title of the pool")] string name,
            [Summary("pool_type", "The type of pool (Fixed, Dynamic, Jackpot, Custom)")] PoolType poolType,
            [Summary("description", "Optional description of the pool")] string? description = null)
        {
            try
            {
                var result = _createPoolLogic.CreatePoolProcess(Context, name, poolType, description);
                await RespondAsync(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Command Error: {ex}");
                await RespondAsync("An error occurred while processing this command.", ephemeral: true);
            }
        }

        
        [SlashCommand("lock_targets", "Lock in targets of pool.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task LockTargetsAsync(
            [Summary("pool_id", "The ID of the pool to lock targets in.")] string poolId)
        {
            var result = _lockTargetsLogic.LockTargetsProcess(Context, poolId);
            await RespondAsync(result);
        }

        [SlashCommand("unlock_targets", "Unlock in targets of pool.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task UnlockTargetsAsync(
            [Summary("pool_id", "The ID of the pool to unlock targets in.")] string poolId)
        {
            var result = _unlockTargetsLogic.UnlockTargetsProcess(Context, poolId);
            await RespondAsync(result);
        }

        [SlashCommand("set_target", "Add two targets to given pool.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task SetTargetAsync(
            [Summary("pool_id", "The pool ID to add a target to")] string poolId,
            [Summary("target_position", "The position to set the target at")] PoolTarget targetPosition,
            [Summary("target_name", "The name you want to give the target")] string name,
            [Summary("odds", "The odds to set for the target")] decimal odds,
            [Summary("description", "Optional description of the target")] string? description = null)
        {
            var result = _setTargetLogic.SetTargetProcess(Context, poolId, targetPosition, name, odds, description);
            await RespondAsync(result);
        }

        [SlashCommand("set_odds", "Edits the odds for a choice in given pool before it opens.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task SetOddsAsync(
            [Summary("pool_id", "The pool ID to set odds in")] string poolId,
            [Summary("pool_target", "The target to change the odds in")] PoolTarget target,
            [Summary("odds", "The new odds amount to set to the given choice")] decimal odds)
        {
            var result = _setOddsLogic.SetOddsProcess(Context, poolId, target, odds);
            await RespondAsync(result);
        }

        [SlashCommand("open", "Set the pool status of given Pool to Open, allowing wagers.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task OpenPoolAsync()
        {
            await RespondWithModalAsync<OpenPoolModal>("open_pool");
        }

        [SlashCommand("close", "Set the pool status of given Pool to Closed, not allowing wagers.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task ClosePoolAsync()
        {
            await RespondWithModalAsync<ClosePoolModal>("close_pool");
        }

        [SlashCommand("submit_winner", "Designates which target is the winner.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task SubmitWinnerAsync(
            [Summary("pool_id", "The pool ID to add the winner to")] string poolId,
            [Summary("pool_target", "Which target to submit as the winner")] PoolTarget poolTarget
            )
        {
            var result = _submitWinnerLogic.SubmitWinnerProcess(Context, poolId, poolTarget);
            await RespondAsync(result);
        }

        [SlashCommand("resolve", "Set the pool status of given Pool to Resolved, and send payouts.")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task ResolvePoolAsync()
        {
            await RespondWithModalAsync<ResolvePoolModal>("resolve_pool");
        }

        [SlashCommand("delete", "Deletes the given pool, reimburses all wagers")]
        [RequireCurrencySetup]
        [RequireUserRegistered]
        public async Task DeletePoolAsync()
        {
            await RespondWithModalAsync<DeletePoolModal>("delete_pool");
        }
    }
}
