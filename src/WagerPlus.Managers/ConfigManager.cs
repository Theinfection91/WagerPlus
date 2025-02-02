using System;
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

        public List<ulong> GetMonetizedChannels()
        {
            return _dataManager.CurrencyConfigFile.MonetizedChannels;
        }

        public void AddToMonetizedChannels(ulong channelId)
        {
            _dataManager.CurrencyConfigFile.MonetizedChannels.Add(channelId);
            _dataManager.SaveAndReloadCurrencyConfigFile();
        }

        public void RemoveFromMonetizedChannels(ulong channelId)
        {
            for (int i = 0; i < _dataManager.CurrencyConfigFile.MonetizedChannels.Count; i++)
            {
                if (_dataManager.CurrencyConfigFile.MonetizedChannels[i].Equals(channelId))
                {
                    _dataManager.CurrencyConfigFile.MonetizedChannels.RemoveAt(i);
                    _dataManager.SaveAndReloadCurrencyConfigFile();
                    break;
                }
            }
        }

        public bool IsChannelMonetized(ulong channelId)
        {
            foreach (ulong channel in _dataManager.CurrencyConfigFile.MonetizedChannels)
            {
                if (channel.Equals(channelId))
                {
                    return true;
                }
            }
            return false;
        }

        public int GetMessageValueAmount()
        {
            return _dataManager.CurrencyConfigFile.MessageValue;
        }

        public void SetMessageValueAmount(int amount)
        {
            _dataManager.CurrencyConfigFile.MessageValue = amount;
            _dataManager.SaveAndReloadCurrencyConfigFile();
        }

        public TimeSpan GetMessageCooldownAmount()
        {
            return _dataManager.CurrencyConfigFile.MessageCooldown;
        }

        public void SetMessageCooldownAmount(TimeSpan seconds)
        {
            _dataManager.CurrencyConfigFile.MessageCooldown = seconds;
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
