﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.MyTournament.Models
{
    public abstract class NPC
    {
        public string Name { get; set; }

        public NPC(string name)
        {
            Name = name;
        }
    }
}
