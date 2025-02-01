using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class ResolvePoolLogic : Logic
    {
        private PoolManager _poolManager;
        public ResolvePoolLogic(PoolManager poolManager) : base("Resolve Pool")
        {
            _poolManager = poolManager;
        }

        public string ResolvePoolProcess(SocketInteractionContext context, string poolIdOne, string poolIdTwo)
        {
            return "WIP";
        }
    }
}
