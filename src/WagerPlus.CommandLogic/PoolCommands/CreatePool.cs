using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Core.Enums;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class CreatePool : Logic
    {
        private PoolManager _poolManager;

        public CreatePool(PoolManager poolManager) : base("Create Pool")
        {
            _poolManager = poolManager;
        }

        public string CreatePoolLogic(SocketInteractionContext context, string name, PoolType poolType, string? description = null)
        {
            _poolManager.CreateAndAddNewPool(name, poolType, context.User.Id, context.User.Username, description);
            return "Let's see";
        }
    }
}
