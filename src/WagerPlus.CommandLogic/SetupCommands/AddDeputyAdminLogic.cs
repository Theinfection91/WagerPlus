using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.SetupCommands
{
    public class AddDeputyAdminLogic : Logic
    {
        private ConfigManager _configManager;
        public AddDeputyAdminLogic(ConfigManager configManager) : base("Add Deputy Admin")
        {
            _configManager = configManager;
        }

        public string AddDeputyAdminProcess(ulong discordId)
        {
            if (_configManager.IsDeputyAdmin(discordId))
                return $"{discordId} is already a Deputy Admin.";
            
            _configManager.AddDeputyAdminToList(discordId);
            return $"{discordId} was added to the Deputy Admin list! They may create and manage pools of their own just like a Bookie, but also with the added benefit of being able to control and edit any pool like a Guild/Server Admin.";
        }
    }
}
