﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.Handlers;

namespace WagerPlus.Managers
{
    public class ConfigManager : Manager
    {
        #region Fields and Constructor

        public ConfigManager(DataManager dataManager) : base("ConfigManager", dataManager)
        {
            
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
