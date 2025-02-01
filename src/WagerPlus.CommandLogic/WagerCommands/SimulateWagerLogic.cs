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
    public class SimulateWagerLogic : Logic
    {
        private PoolManager _poolManager;
        public SimulateWagerLogic(PoolManager poolManager) : base("Simulate Wager")
        {
            _poolManager = poolManager;
        }

        public string SimulateWagerProcess(string poolId, PoolTarget target, int wagerAmount)
        {
            // Check if pool by given name exists
            if (_poolManager.IsPoolIdInDatabase(poolId))
            {
                // Grab pool
                Pool? pool = _poolManager.GetPoolById(poolId);

                // Check if pool is open for wagers
                if (_poolManager.IsPoolOpen(pool))
                {
                    return $"Placing a wager of {wagerAmount} on {target} in {pool.Name} would win you {pool.GetProjectedPayoutBasedOnWager(target, wagerAmount)} (Profit: {pool.GetProjectedPayoutBasedOnWager(target, wagerAmount) - wagerAmount})";
                }
                return $"**{pool.Name}** is not currently open so the odds may not be what they intend to be when it does. Try again later.";
            }
            return $"No pool found by the Id of **{poolId}**";
        }
    }
}
