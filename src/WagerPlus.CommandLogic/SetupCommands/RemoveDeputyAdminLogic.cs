using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.SetupCommands
{
    public class RemoveDeputyAdminLogic : Logic
    {
        private ConfigManager _configManager;
        public RemoveDeputyAdminLogic(ConfigManager configManager) : base("Remove Deputy Admin")
        {
            _configManager = configManager;
        }

        public string RemoveDeputyAdminProcess(ulong discordId)
        {
            if (!_configManager.IsDeputyAdmin(discordId))
                return $"{discordId} is not a Deputy Admin";

            _configManager.RemoveDeputyAdminFromList(discordId);
            return $"{discordId} was removed from the Deputy Admin list.";
        }
    }
}
