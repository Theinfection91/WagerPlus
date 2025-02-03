using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using Discord.WebSocket;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class CreatePoolLogic : Logic
    {
        private ConfigManager _configManager;
        private PoolManager _poolManager;

        public CreatePoolLogic(ConfigManager configManager, PoolManager poolManager) : base("Create Pool")
        {
            _configManager = configManager;
            _poolManager = poolManager;
        }

        public string CreatePoolProcess(SocketInteractionContext context, string name, PoolType poolType, string? description = null)
        {
            // Check if user is a guild admin
            bool isGuildAdmin = (context.User as SocketGuildUser)?.GuildPermissions.Administrator ?? false;

            // Check if user has required permissions
            if (!_configManager.GetCanAnyoneCreatePools() &&
                !_configManager.IsBookie(context.User.Id) &&
                !_configManager.IsDeputyAdmin(context.User.Id) &&
                !isGuildAdmin)
                return $"You are not allowed to create pools.";

            string newId = _poolManager.GeneratePoolId();

            switch (poolType)
            {
                case PoolType.Fixed:
                    FixedPool fixedPool = new(name, poolType, context.User.Id, context.User.Username, description)
                    {
                        Id = newId
                    };
                    _poolManager.AddPool(fixedPool);
                    return $"A new {poolType} Odds Pool named {fixedPool.Name} has been created by {fixedPool.OwnerDisplayName}! The Pool ID generated is: **{fixedPool.Id}**\n\nSet targets with `/pool set_target`, then use `/pool lock_targets`. Change odds with `/pool set_odds` before the pool is opened or targets are locked!";

                case PoolType.Dynamic:
                    DynamicPool dynamicPool = new(name, poolType, context.User.Id, context.User.Username, description)
                    {
                        Id = newId
                    };
                    _poolManager.AddPool(dynamicPool);
                    return $"A new {poolType} Odds Pool named {dynamicPool.Name} has been created by {dynamicPool.OwnerDisplayName}! The Pool ID generated is: **{dynamicPool.Id}**\n\nSet targets with `/pool set_target`, then use `/pool lock_targets`. Change odds with `/pool set_odds` before the pool is opened or targets are locked!";

                default:
                    return "Invalid PoolType given.";
            }
        }

    }
}
