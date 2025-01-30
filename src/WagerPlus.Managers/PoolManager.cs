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

        public void LoadBettingsPoolDatabase()
        {
            _dataManager.LoadBettingPoolsDatabase();
        }

        public void SaveBettingsPoolDatabase()
        {
            _dataManager.SaveBettingPoolsDatabase(_dataManager.BettingPoolsDatabase);
        }

        public void SaveAndReloadBettingsPoolDatabase()
        {
            SaveBettingsPoolDatabase();
            LoadBettingsPoolDatabase();
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
