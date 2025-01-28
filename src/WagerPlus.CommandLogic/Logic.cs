using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.CommandLogic
{
    public abstract class Logic
    {
        public required string Name { get; set; }

        protected Logic(string name)
        {
            Name = name;
        }
    }
}
