using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.SetupCommands
{
    public class UsersCanCreatePoolsLogic : Logic
    {
        private ConfigManager _configManager;
        public UsersCanCreatePoolsLogic(ConfigManager configManager) : base("Users Can Create Pools")
        {
            _configManager = configManager;
        }

        public string UsersCanCreatePoolsProcess(bool trueOrFalse)
        {
            if (trueOrFalse.Equals(_configManager.GetCanAnyoneCreatePools()))
                return $"The `{Name}` option is already set to {trueOrFalse}";

            _configManager.SetCanAnyoneCreatePools(trueOrFalse);
            return $"The `{Name}` option has been set to {trueOrFalse}.";
        }
    }
}
