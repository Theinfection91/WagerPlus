using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Models.Pools;

namespace WagerPlus.Data.DataModels
{
    public class BettingPools
    {
        public List<Pool> Pools { get; set; } = [];
        
        public BettingPools() { }
    }
}
