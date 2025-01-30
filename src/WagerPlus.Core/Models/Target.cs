using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Models
{
    public class Target
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public object? Object { get; set; }

        public Target(string name, string? description = null)
        {
            Name = name;
            Description = description ?? string.Empty;
        }
    }
}
