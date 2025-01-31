﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums;

namespace WagerPlus.Core.Models
{
    public class Choice
    {
        public string Title { get; set; }
        public string? Description { get; set; }
        public Target Target { get; set; }
        public WagerCondition Condition { get; set; }

        public Choice(string title, Target target, WagerCondition condition, string? description = null)
        {
            Title = title;
            Description = description ?? string.Empty;
            Target = target;
            Condition = condition;
        }
    }
}
