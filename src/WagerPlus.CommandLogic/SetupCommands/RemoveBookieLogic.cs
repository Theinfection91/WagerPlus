using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.SetupCommands
{
    public class RemoveBookieLogic : Logic
    {
        private ConfigManager _configManager;
        public RemoveBookieLogic(ConfigManager configManager) : base("Remove Bookie")
        {
            _configManager = configManager;
        }

        public string RemoveBookieProcess(ulong discordId)
        {
            if (!_configManager.IsBookie(discordId))
                return $"{discordId} is not a Bookie.";

            _configManager.RemoveBookieFromList(discordId);
            return $"{discordId} was removed from the Bookie list.";
        }
    }
}
