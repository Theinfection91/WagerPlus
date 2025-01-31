﻿using System;
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
        public DiscordCredentialFile DiscordConfigFile {  get; set; }
        private readonly DiscordCredentialHandler _discordConfigHandler;

        // User Profiles Data
        public UserProfileList UserProfileList { get; set; }
        private readonly UserProfileHandler _userProfileHandler;

        public DataManager(BettingPoolsHandler bettingPoolsHandler, CurrencyConfigHandler currencyConfigHandler, DiscordCredentialHandler discordConfigHandler, UserProfileHandler userProfileHandler)
        {
            _betttingPoolsHandler = bettingPoolsHandler;
            LoadBettingPoolsDatabase();

            _currencyConfigHandler = currencyConfigHandler;
            LoadCurrencyConfigFile();
            
            _discordConfigHandler = discordConfigHandler;
            LoadDiscordConfigFile();

            _userProfileHandler = userProfileHandler;
            LoadUserProfileList();
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

        public void SaveDiscordConfigFile(DiscordCredentialFile discordConfigFile)
        {
            _discordConfigHandler.Save(discordConfigFile);
        }

        public void SaveAndReloadDiscordConfigFile()
        {
            SaveDiscordConfigFile(DiscordConfigFile);
            LoadDiscordConfigFile();
        }
        #endregion

        #region User Profile List Data
        public void LoadUserProfileList()
        {
            UserProfileList = _userProfileHandler.Load();
        }

        public void SaveUserProfileList(UserProfileList userProfileList)
        {
            _userProfileHandler.Save(userProfileList);
        }

        public void SaveAndReloadUserProfileList()
        {
            SaveUserProfileList(UserProfileList);
            LoadUserProfileList();
        }
        #endregion
    }
}
