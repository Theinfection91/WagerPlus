using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.WagerCommands
{
    public class MinimumWagerLogic : Logic
    {
        private PoolManager _poolManager;
        public MinimumWagerLogic(PoolManager poolManager) : base("Minimum Wager")
        {
            _poolManager = poolManager;
        }

        public string MinimumWagerProcess(string poolId, PoolTarget target)
        {
            // Check if pool by given name exists
            if (!_poolManager.IsPoolIdInDatabase(poolId))
                return $"No pool found by the Id of **{poolId}**";

            // Grab pool
            Pool? pool = _poolManager.GetPoolById(poolId);

            // Check if pool is open for wagers
            if (!_poolManager.IsPoolOpen(pool) && pool.Status != PoolStatus.Resolved)
                return $"**{pool.Id}** is not currently open so the odds may not be what they intend to be when it does. Try again later.";

            if (pool.Status.Equals(PoolStatus.Resolved))
                return $"**{pool.Id}** has already been resolved and it is too late to check wager minimum amounts.";

            return $"To gain a profit on {target.ToString()} in {pool.Id} you would have to place a minimum wager amount of {pool.GetMinimumBetForProfit(target)}.";
        }
    }
}
