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

        public void AddPool(Pool pool)
        {
            _dataManager.AddPoolToDatabase(pool);
        }
    }
}
