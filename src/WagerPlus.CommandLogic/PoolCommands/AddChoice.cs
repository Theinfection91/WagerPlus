using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Discord;
using Discord.Interactions;
using WagerPlus.Core.Enums;

namespace WagerPlus.CommandLogic.PoolCommands
{
    public class AddChoice : Logic
    {
        public AddChoice() : base ("Add Pool Choice")
        {

        }

        public string AddChoiceLogic(SocketInteractionContext context, string title, string target, WagerCondition condition, string? description = null)
        {
            return null;
        }
    }
}
