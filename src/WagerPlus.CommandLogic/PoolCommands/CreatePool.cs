using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Core.Enums;
using WagerPlus.Core.Models;
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
            Pool newPool = new(name, poolType, context.User.Id, context.User.Username, description);
            _poolManager.AddPool(newPool);
            return $"A new {poolType.ToString()} Pool named {newPool.Name} has been created by {newPool.OwnerDisplayName}!";
        }
    }
}
