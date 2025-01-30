using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Core.Models.Pools
{
    public class DynamicPool : Pool
    {
        public DynamicPool(string name, PoolType poolType, ulong ownerDiscordId, string ownerDisplayName, string? description = null) : base(name, poolType, ownerDiscordId, ownerDisplayName, description)
        {

        }
    }
}
