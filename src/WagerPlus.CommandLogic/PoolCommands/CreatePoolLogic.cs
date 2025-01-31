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
                    return $"A new {poolType.ToString()} Odds Pool named {fixedPool.Name} has been created by {fixedPool.OwnerDisplayName}! Default odds have been set to **{fixedPool.ChoiceOneOdds}** - Change odds with `/pool set_odds` before a pool is opened!";

                case PoolType.Dynamic:
                    DynamicPool dynamicPool = new(name, poolType, context.User.Id, context.User.Username, description)
                    {
                        Id = newId
                    };
                    _poolManager.AddPool(dynamicPool);
                    return $"A new {poolType.ToString()} Odds Pool named {dynamicPool.Name} has been created by {dynamicPool.OwnerDisplayName}! Default starting odds have been set to **{dynamicPool.ChoiceOneOdds}** - Change odds with `/pool set_odds` before a pool is opened!";

                default:
                    return "Invalid PoolType given.";
            }
        }
    }
}
