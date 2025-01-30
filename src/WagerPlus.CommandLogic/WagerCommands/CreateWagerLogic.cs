using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Managers;

namespace WagerPlus.CommandLogic.WagerCommands
{
    public class CreateWagerLogic : Logic
    {
        private PoolManager _poolManager;
        private WagerManager _wagerManager;

        public CreateWagerLogic(PoolManager poolManager, WagerManager wagerManager) : base("Create Wager")
        {
            _poolManager = poolManager;
            _wagerManager = wagerManager;
        }
    }
}
