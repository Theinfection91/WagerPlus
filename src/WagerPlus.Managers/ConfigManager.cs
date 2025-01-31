﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.Handlers;

namespace WagerPlus.Managers
{
    public class ConfigManager : DataDriven
    {
        #region Fields and Constructor

        public ConfigManager(DataManager dataManager) : base("ConfigManager", dataManager)
        {
            
        }
        #endregion

        #region Currency Config
        public string GetCurrencyName()
        {
            return _dataManager.CurrencyConfigFile.CurrencyName;
        }

        public void SetCurrencyName(string currencyName)
        {
            _dataManager.CurrencyConfigFile.CurrencyName = currencyName;
        }

        public string GetCurrencyAbbreviation()
        {
            return _dataManager.CurrencyConfigFile.CurrencyAbbreviation;
        }

        public void SetCurrentAbbreviation(string currencyAbbreviation)
        {
            _dataManager.CurrencyConfigFile.CurrencyAbbreviation = currencyAbbreviation;
        }

        public bool GetIsCurrencySetupComplete()
        {
            return _dataManager.CurrencyConfigFile.IsCurrencySetupComplete;
        }

        public void SetIsCurrencySetupComplete(bool isComplete)
        {
            _dataManager.CurrencyConfigFile.IsCurrencySetupComplete = isComplete;
            _dataManager.SaveAndReloadCurrencyConfigFile();
        }
        #endregion

        #region Discord Config
        public string GetCommandPrefix()
        {
            return _dataManager.DiscordConfigFile.CommandPrefix;
        }

        public void SetCommandPrefix(string prefix)
        {
            _dataManager.DiscordConfigFile.CommandPrefix = prefix;
            _dataManager.SaveDiscordConfigFile(_dataManager.DiscordConfigFile);
        }

        public string GetDiscordToken()
        {
            return _dataManager.DiscordConfigFile.DiscordBotToken;
        }

        public void SetDiscordToken(string discordToken)
        {
            _dataManager.DiscordConfigFile.DiscordBotToken = discordToken;
            _dataManager.SaveDiscordConfigFile(_dataManager.DiscordConfigFile);
        }

        public ulong GetGuildId()
        {
            return _dataManager.DiscordConfigFile.GuildId;
        }

        public void SetGuildId(ulong guildId)
        {
            _dataManager.DiscordConfigFile.GuildId = guildId;
            _dataManager.SaveDiscordConfigFile(_dataManager.DiscordConfigFile);
        }        
        #endregion
    }
}
