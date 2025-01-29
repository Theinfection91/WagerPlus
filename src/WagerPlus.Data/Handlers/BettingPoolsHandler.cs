using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Data.DataModels;

namespace WagerPlus.Data.Handlers
{
    public class BettingPoolsHandler : DataHandler<BettingPools>
    {
        public BettingPoolsHandler() : base("betting_pools.json", "Databases")
        {

        }
    }
}
