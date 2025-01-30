using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Models.Pools;
using WagerPlus.Data.DataModels;
using WagerPlus.Data.Handlers;

namespace WagerPlus.Managers
{
    public class DataManager
    {
        #region Fields and Constructor
        public string Name { get; set; } = "DataManager";

        // Betting Pools Data
        public BettingPools BettingPoolsDatabase { get; set; }
        private BettingPoolsHandler _betttingPoolsHandler;

        // Currency Config
        public CurrencyConfigFile CurrencyConfigFile { get; set; }
        private readonly CurrencyConfigHandler _currencyConfigHandler;

        // Discord Config
        public DiscordConfigFile DiscordConfigFile {  get; set; }
        private readonly DiscordConfigHandler _discordConfigHandler;

        public DataManager(BettingPoolsHandler bettingPoolsHandler, CurrencyConfigHandler currencyConfigHandler, DiscordConfigHandler discordConfigHandler)
        {
            _betttingPoolsHandler = bettingPoolsHandler;
            LoadBettingPoolsDatabase();

            _currencyConfigHandler = currencyConfigHandler;
            LoadCurrencyConfigFile();
            
            _discordConfigHandler = discordConfigHandler;
            LoadDiscordConfigFile();
        }
        #endregion

        #region Betting Pools Data
        public void LoadBettingPoolsDatabase()
        {
            BettingPoolsDatabase = _betttingPoolsHandler.Load();
        }

        public void SaveBettingPoolsDatabase(BettingPools bettingPools)
        {
            _betttingPoolsHandler.Save(bettingPools);
        }

        public void SaveAndReloadBettingPoolsDatabase()
        {
            SaveBettingPoolsDatabase(BettingPoolsDatabase);
            LoadBettingPoolsDatabase();
        }

        public void AddPoolToDatabase(Pool pool)
        {
            if (pool != null)
            {
                BettingPoolsDatabase.Pools.Add(pool);
                SaveAndReloadBettingPoolsDatabase();
            }
        }
        #endregion

        #region Currency Configuration
        public void LoadCurrencyConfigFile()
        {
            CurrencyConfigFile = _currencyConfigHandler.Load();
        }

        public void SaveCurrencyConfigFile(CurrencyConfigFile currencyConfigFile)
        {
            _currencyConfigHandler.Save(currencyConfigFile);
        }

        public void SaveAndReloadCurrencyConfigFile()
        {
            SaveCurrencyConfigFile(CurrencyConfigFile);
            LoadCurrencyConfigFile();
        }
        #endregion

        #region Discord Configuration
        public void LoadDiscordConfigFile()
        {
            DiscordConfigFile = _discordConfigHandler.Load();
        }

        public void SaveDiscordConfigFile(DiscordConfigFile discordConfigFile)
        {
            _discordConfigHandler.Save(discordConfigFile);
        }

        public void SaveAndReloadDiscordConfigFile()
        {
            SaveDiscordConfigFile(DiscordConfigFile);
            LoadDiscordConfigFile();
        }
        #endregion
    }
}
