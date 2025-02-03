using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.SetupCommands
{
    public class AddBookieLogic : Logic
    {
        ConfigManager _configManager;
        public AddBookieLogic(ConfigManager configManager) : base("Add Bookie")
        {
            _configManager = configManager;
        }

        public string AddBookieProcess(ulong discordId)
        {
            if (_configManager.IsBookie(discordId))
                return $"{discordId} is already registered as a Bookie.";
            
            _configManager.AddBookieToList(discordId);
            return $"{discordId} was added to the Bookie list! They may create and manage pools of their own.";
        }
    }
}
