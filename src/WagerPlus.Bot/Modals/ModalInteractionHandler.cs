using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Bot.Modals.PoolModals;
using WagerPlus.CommandLogic.PoolCommands;

namespace WagerPlus.Bot.Modals
{
    public class ModalInteractionHandler : InteractionModuleBase<SocketInteractionContext>
    {
        private ClosePoolLogic _closePoolLogic;
        private OpenPoolLogic _openPoolLogic;
        private ResolvePoolLogic _resolvePoolLogic;
        private DeletePoolLogic _deletePoolLogic;

        public ModalInteractionHandler(ClosePoolLogic closePoolLogic, OpenPoolLogic openPoolLogic, ResolvePoolLogic resolvePoolLogic, DeletePoolLogic deletePoolLogic)
        {
            _closePoolLogic = closePoolLogic;
            _openPoolLogic = openPoolLogic;
            _resolvePoolLogic = resolvePoolLogic;
            _deletePoolLogic = deletePoolLogic;
        }

        [ModalInteraction("open_pool")]
        public async Task HandleOpenPoolAsync(OpenPoolModal openPoolModal)
        {
            string poolIdOne = openPoolModal.PoolIdOne;
            string poolIdTwo = openPoolModal.PoolIdTwo;

            var result = _openPoolLogic.OpenPoolProcess(Context, poolIdOne, poolIdTwo);
            await RespondAsync(result);
        }

        [ModalInteraction("close_pool")]
        public async Task HandleClosePoolAsync(ClosePoolModal closePoolModal)
        {
            string poolIdOne = closePoolModal.PoolIdOne;
            string poolIdTwo = closePoolModal.PoolIdTwo;

            var result = _closePoolLogic.ClosePoolProcess(Context, poolIdOne, poolIdTwo);
            await RespondAsync(result);
        }

        [ModalInteraction("resolve_pool")]
        public async Task ResolvePoolAsync(ResolvePoolModal resolvePoolModal)
        {
            string poolIdOne = resolvePoolModal.PoolIdOne;
            string poolIdTwo = resolvePoolModal.PoolIdTwo;

            var result = _resolvePoolLogic.ResolvePoolProcess(Context, poolIdOne, poolIdTwo);
            await RespondAsync(result);
        }

        [ModalInteraction("delete_pool")]
        public async Task DeletePoolAsync(DeletePoolModal deletePoolModal)
        {
            string poolIdOne = deletePoolModal.PoolIdOne;
            string poolIdTwo = deletePoolModal.PoolIdTwo;

            var result = _deletePoolLogic.DeletePoolProcess(Context, poolIdOne, poolIdTwo);
            await RespondAsync(result);
        }
    }
}
