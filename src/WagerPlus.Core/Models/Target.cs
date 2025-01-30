using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums.PoolEnums;

namespace WagerPlus.Core.Models
{
    public class Target
    {
        public string Name { get; set; }
        public PoolTarget PoolTarget { get; set; }
        public string? Description { get; set; }
        public object? Object { get; set; }

        public Target(string name, PoolTarget poolTarget, string? description = null)
        {
            Name = name;
            PoolTarget = poolTarget;
            Description = description ?? string.Empty;
        }
    }
}
