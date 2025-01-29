using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Managers
{
    public abstract class Manager
    {
        public required string Name {  get; set; }
        internal DataManager _dataManager;

        public Manager(string name, DataManager dataManager)
        {
            Name = name;
            _dataManager = dataManager;
        }
    }
}
