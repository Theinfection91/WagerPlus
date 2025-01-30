using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class CreatePoolLogic : Logic
    {
        private PoolManager _poolManager;

        public CreatePoolLogic(PoolManager poolManager) : base("Create Pool")
        {
            _poolManager = poolManager;
        }

        public string CreatePoolProcess(SocketInteractionContext context, string name, PoolType poolType, string? description = null)
        {
            Pool newPool = new(name, poolType, context.User.Id, context.User.Username, description);
            _poolManager.AddPool(newPool);

            return $"A new {poolType.ToString()} Pool named {newPool.Name} has been created by {newPool.OwnerDisplayName}!";
        }
    }
}
