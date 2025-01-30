using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord.Interactions;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.CurrencyCommands
{
    public class SetupCurrencyLogic : Logic
    {
        private ConfigManager _configManager;

        public SetupCurrencyLogic(ConfigManager configManager) : base("Setup Currency")
        {
            _configManager = configManager;
        }

        public string SetupCurrencyProcess(string currencyName, string currencyAbbreviation)
        {
            if (!_configManager.GetIsCurrencySetupComplete())
            {
                _configManager.SetCurrencyName(currencyName);
                _configManager.SetCurrentAbbreviation(currencyAbbreviation);
                _configManager.SetIsCurrencySetupComplete(true);
                return $"{_configManager.GetIsCurrencySetupComplete()} - {_configManager.GetCurrencyName()} - {_configManager.GetCurrencyAbbreviation()}";
            }
            return $"Currency setup is already set to {_configManager.GetIsCurrencySetupComplete()}";
        }
    }
}
