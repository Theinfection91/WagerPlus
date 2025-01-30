using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Managers
{
    public abstract class DataDriven
    {
        public required string Name {  get; set; }
        internal DataManager _dataManager;

        public DataDriven(string name, DataManager dataManager)
        {
            Name = name;
            _dataManager = dataManager;
        }
    }
}
