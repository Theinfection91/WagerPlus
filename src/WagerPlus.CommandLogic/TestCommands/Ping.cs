using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.CommandLogic.TestCommands
{
    public class Ping : Logic
    {
        public Ping() : base("Ping")
        {

        }

        public string PingLogic()
        {
            return "pong";
        }
    }
}