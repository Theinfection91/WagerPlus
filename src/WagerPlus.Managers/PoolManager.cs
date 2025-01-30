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

        public bool IsPoolIdInDatabase(string poolId)
        {
            foreach (Pool pool in _dataManager.BettingPoolsDatabase.Pools)
            {
                if (pool.Id.Equals(poolId))
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

        public bool IsTargetNameUnique(string poolName, string targetName)
        {
            Pool? pool = GetPoolByName(poolName);
            foreach (var target in pool.Targets)
            {
                if (string.Equals(target.Value.Name, targetName, StringComparison.OrdinalIgnoreCase))
                {
                    return false;
                }
            }
            return true;
        }

        public bool IsBothTargetsSetInPool(Pool pool)
        {
            if (pool.Targets.Count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsChoicesGeneratedInPool(Pool pool)
        {
            if (pool.Choices.Count == 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsUserPoolOwner(ulong discordId, Pool pool)
        {
            if (discordId.Equals(pool.OwnerDiscordId))
            {
                return true;
            }
            return false;
        }

        public PoolTarget GetCorrectTargetEnum(Pool pool)
        {

            if (pool.Targets.Count == 0)
            {
                return PoolTarget.TargetOne;
            }
            else
            {
                return PoolTarget.TargetTwo;
            }
        }

        public (Choice, Choice) GetCorrectChoices(Pool pool)
        {
            Choice? choiceOne = null;
            Choice? choiceTwo = null;

            foreach (var target in pool.Targets)
            {
                if (target.Value.PoolTarget == PoolTarget.TargetOne)
                {
                    choiceOne = new Choice($"{target.Value.Name} {WagerCondition.Win}s", target.Value, WagerCondition.Win);
                }
                else if (target.Value.PoolTarget == PoolTarget.TargetTwo)
                {
                    choiceTwo = new Choice($"{target.Value.Name} {WagerCondition.Win}s", target.Value, WagerCondition.Win);
                }
            }
            return (choiceOne, choiceTwo);
        }

        public Pool? GetPoolById(string poolId)
        {
            foreach (Pool pool in _dataManager.BettingPoolsDatabase.Pools)
            {
                if (pool.Id.Equals(poolId))
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
                uniqueId = $"P{randomInt}{(_dataManager.BettingPoolsDatabase.Pools.Count + 1)}";

                // Check if the ID is unique in the database
                if (!IsPoolIdInDatabase(uniqueId))
                {
                    isPoolIdUnique = true;
                    return uniqueId;
                }
            }

            return null;
        }


        public void AddPool(Pool pool)
        {
            _dataManager.AddPoolToDatabase(pool);
        }
    }
}
