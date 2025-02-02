using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums;
using WagerPlus.Core.Enums.PoolEnums;
using WagerPlus.Core.Models;
using WagerPlus.Core.Models.Pools;

namespace WagerPlus.Managers
{
    public class PoolManager : DataDriven
    {
        public PoolManager(DataManager dataManager) : base("PoolManager", dataManager)
        {

        }

        public void LoadBettingPoolsDatabase()
        {
            _dataManager.LoadBettingPoolsDatabase();
        }

        public void SaveBettingPoolsDatabase()
        {
            _dataManager.SaveBettingPoolsDatabase(_dataManager.BettingPoolsDatabase);
        }

        public void SaveAndReloadBettingPoolsDatabase()
        {
            SaveBettingPoolsDatabase();
            LoadBettingPoolsDatabase();
        }

        public bool IsOddsAmountValid(decimal odds)
        {
            return odds >= 1.01m;
        }

        public bool IsPoolIdInDatabase(string poolId)
        {
            foreach (Pool pool in _dataManager.BettingPoolsDatabase.Pools)
            {
                if (pool.Id.Equals(poolId, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public bool IsPoolNameUnique(string poolName)
        {
            foreach (Pool pool in _dataManager.BettingPoolsDatabase.Pools)
            {
                if (pool.Name.Equals(poolName, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsPoolOpen(Pool pool)
        {
            if (pool.Status.Equals(PoolStatus.Open))
            {
                return true;
            }
            return false;
        }

        public bool IsTargetNameUnique(string poolId, string targetName)
        {
            Pool? pool = GetPoolById(poolId);

            if (pool == null)
                return true; // Assuming null means no existing pool, thus unique.

            // If both targets are null, name is unique
            if (pool.TargetOne == null && pool.TargetTwo == null)
                return true;

            // If only TargetOne is null but TargetTwo exists, check TargetTwo
            if (pool.TargetOne == null)
                return pool.TargetTwo.Name != targetName;

            // If only TargetTwo is null but TargetOne exists, check TargetOne
            if (pool.TargetTwo == null)
                return pool.TargetOne.Name != targetName;

            // If both exist, check both names
            return pool.TargetOne.Name != targetName && pool.TargetTwo.Name != targetName;
        }


        public bool IsBothTargetsSetInPool(Pool pool)
        {
            if (pool.TargetOne != null && pool.TargetTwo != null)
                return true;
            return false;
        }

        public bool IsTargetsLocked(Pool pool)
        {
            return pool.IsTargetsLocked;
        }

        public bool IsUserPoolOwner(ulong discordId, Pool pool)
        {
            if (discordId.Equals(pool.OwnerDiscordId))
            {
                return true;
            }
            return false;
        }

        public Pool? GetPoolById(string poolId)
        {
            foreach (Pool pool in _dataManager.BettingPoolsDatabase.Pools)
            {
                if (pool.Id.Equals(poolId, StringComparison.OrdinalIgnoreCase))
                {
                    return pool;
                }
            }
            return null;
        }

        public Pool? GetPoolByName(string poolName)
        {
            foreach (Pool pool in _dataManager.BettingPoolsDatabase.Pools)
            {
                if (pool.Name.Equals(poolName, StringComparison.OrdinalIgnoreCase))
                {
                    return pool;
                }
            }
            return null;
        }

        public string? GeneratePoolId()
        {
            bool isPoolIdUnique = false;
            string uniqueId;

            while (!isPoolIdUnique)
            {
                Random random = new();
                int randomInt = random.Next(100, 1000);
                uniqueId = $"P{randomInt}";

                // Check if the ID is unique in the database
                if (!IsPoolIdInDatabase(uniqueId))
                {
                    isPoolIdUnique = true;
                    return uniqueId;
                }
            }

            return null;
        }

        public void SetPoolStatus(Pool pool, PoolStatus poolStatus)
        {
            pool.Status = poolStatus;
            SetTimeStamp(pool, poolStatus);
        }

        public void SetTargetsLocked(Pool pool, bool trueOrFalse)
        {
            pool.IsTargetsLocked = trueOrFalse;
        }

        public void SetTimeStamp(Pool pool, PoolStatus poolStatus)
        {
            switch (poolStatus)
            {
                case PoolStatus.Open:
                    pool.Opened = DateTime.UtcNow;
                    break;

                case PoolStatus.Closed:
                    pool.Closed = DateTime.UtcNow;
                    break;

                case PoolStatus.Resolved:
                    pool.Resolved = DateTime.UtcNow;
                    break;
            }
        }

        public void AddPool(Pool pool)
        {
            _dataManager.AddPoolToDatabase(pool);
        }
    }
}
