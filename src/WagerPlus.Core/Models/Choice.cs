using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums;

namespace WagerPlus.Core.Models
{
    public class Choice
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public Target Target { get; set; }
        public WagerCondition Condition { get; set; }

        public Choice(string name, Target target, WagerCondition condition, string? description = null)
        {
            Name = name;
            Description = description ?? string.Empty;
            Target = target;
            Condition = condition;
        }
    }
}
