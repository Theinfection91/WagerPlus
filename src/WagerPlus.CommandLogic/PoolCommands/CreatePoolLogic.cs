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
            string newId = _poolManager.GeneratePoolId();
            
            switch (poolType)
            {
                case PoolType.Fixed:
                    FixedPool fixedPool = new(name, poolType, context.User.Id, context.User.Username, description)
                    {
                        Id = newId
                    };
                    _poolManager.AddPool(fixedPool);
                    return $"A new {poolType.ToString()} Odds Pool named {fixedPool.Name} has been created by {fixedPool.OwnerDisplayName}! The Pool ID generated is: **{fixedPool.Id}** \n\nAdd two targets with `/pool add_target` then use `/pool lock_targets` - Change odds with `/pool set_odds` before a pool is opened or targets or locked!";

                case PoolType.Dynamic:
                    DynamicPool dynamicPool = new(name, poolType, context.User.Id, context.User.Username, description)
                    {
                        Id = newId
                    };
                    _poolManager.AddPool(dynamicPool);
                    return $"A new {poolType.ToString()} Odds Pool named {dynamicPool.Name} has been created by {dynamicPool.OwnerDisplayName}! The Pool ID generated is: **{dynamicPool.Id}** \n\nAdd two targets with `/pool add_target` then use `/pool lock_targets` - Change odds with `/pool set_odds` before a pool is opened or targets or locked!\"";

                default:
                    return "Invalid PoolType given.";
            }
        }
    }
}
