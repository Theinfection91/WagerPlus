using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.Handlers;

namespace WagerPlus.Managers
{
    public class ConfigManager
    {
        #region Fields and Constructor
        private DataManager _dataManager;

        public ConfigManager(DataManager dataManager)
        {
            _dataManager = dataManager;
        }
        #endregion

        #region Discord Config
        public string GetCommandPrefix()
        {
            return _dataManager.discordConfigFile.CommandPrefix;
        }

        public void SetCommandPrefix(string prefix)
        {
            _dataManager.discordConfigFile.CommandPrefix = prefix;
            _dataManager.SaveDiscordConfigFile(_dataManager.discordConfigFile);
        }

        public string GetDiscordToken()
        {
            return _dataManager.discordConfigFile.DiscordBotToken;
        }

        public void SetDiscordToken(string discordToken)
        {
            _dataManager.discordConfigFile.DiscordBotToken = discordToken;
            _dataManager.SaveDiscordConfigFile(_dataManager.discordConfigFile);
        }

        public ulong GetGuildId()
        {
            return _dataManager.discordConfigFile.GuildId;
        }

        public void SetGuildId(ulong guildId)
        {
            _dataManager.discordConfigFile.GuildId = guildId;
            _dataManager.SaveDiscordConfigFile(_dataManager.discordConfigFile);
        }        
        #endregion
    }
}
