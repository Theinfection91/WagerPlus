using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;
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

        public int GetDailyRewardAmount()
        {
            return _dataManager.CurrencyConfigFile.DailyRewardAmount;
        }

        public void SetDailyRewardAmount(int amount)
        {
            _dataManager.CurrencyConfigFile.DailyRewardAmount = amount;
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

        #region Permissions Config
        public bool GetCanAnyoneCreatePools()
        {
            return _dataManager.PermissionsConfigFile.CanAnyoneCreatePools;
        }

        public void SetCanAnyoneCreatePools(bool trueOrFalse)
        {
            _dataManager.PermissionsConfigFile.CanAnyoneCreatePools = trueOrFalse;
            _dataManager.SaveAndReloadPermissionsConfigFile();
        }

        public List<ulong> GetAllCertifiedBookies()
        {
            return _dataManager.PermissionsConfigFile.CertifiedBookies;
        }

        public void AddBookieToList(ulong discordId)
        {
            _dataManager.PermissionsConfigFile.CertifiedBookies.Add(discordId);
            _dataManager.SaveAndReloadPermissionsConfigFile();
        }

        public void RemoveBookieFromList(ulong discordId)
        {
            for (int i = 0; i < _dataManager.PermissionsConfigFile.CertifiedBookies.Count; i++)
                if (_dataManager.PermissionsConfigFile.CertifiedBookies[i].Equals(discordId))
                    _dataManager.PermissionsConfigFile.CertifiedBookies.RemoveAt(i);
                    _dataManager.SaveAndReloadPermissionsConfigFile();
        }

        public void AddDeputyAdminToList(ulong discordId)
        {
            _dataManager.PermissionsConfigFile.DeputyAdmins.Add(discordId);
            _dataManager.SaveAndReloadPermissionsConfigFile();
        }

        public void RemoveDeputyAdminFromList(ulong discordId)
        {
            for (int i = 0; i < _dataManager.PermissionsConfigFile.DeputyAdmins.Count; i++)
                if (_dataManager.PermissionsConfigFile.DeputyAdmins[i].Equals(discordId))
                    _dataManager.PermissionsConfigFile.DeputyAdmins.RemoveAt(i);
                    _dataManager.SaveAndReloadPermissionsConfigFile();
        }

        public bool IsBookie(ulong discordId)
        {
            foreach (ulong bookieId in _dataManager.PermissionsConfigFile.CertifiedBookies)
                if (bookieId.Equals(discordId))
                    return true;
            return false;
        }

        public bool IsDeputyAdmin(ulong discordId)
        {
            foreach (ulong adminId in _dataManager.PermissionsConfigFile.DeputyAdmins)
                if (adminId.Equals(discordId))
                    return true;
            return false;
        }
        #endregion
    }
}
