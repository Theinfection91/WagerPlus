using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums;
using WagerPlus.Core.Models;

namespace WagerPlus.Managers
{
    public class PoolManager : DataDrivenManager
    {
        public PoolManager(DataManager dataManager) : base("PoolManager", dataManager)
        {

        }

        public void CreateAndAddNewPool(string name, PoolType poolType, ulong ownerDiscordId, string ownerDiscordDisplayName, string? description = null)
        {
            Pool newPool = new(name, poolType, ownerDiscordId, ownerDiscordDisplayName, description);
            _dataManager.AddPoolToDatabase(newPool);
        }
    }
}
