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
        private OpenPoolLogic _openPoolLogic;

        public ModalInteractionHandler(OpenPoolLogic openPoolLogic)
        {
            _openPoolLogic = openPoolLogic;
        }

        [ModalInteraction("open_pool")]
        public async Task HandleOpenPoolAsync(OpenPoolModal openPoolModal)
        {
            string poolIdOne = openPoolModal.PoolIdOne;
            string poolIdTwo = openPoolModal.PoolIdTwo;

            var result = _openPoolLogic.OpenPoolProcess(Context, poolIdOne, poolIdTwo);
            await RespondAsync(result);
        }
    }
}
