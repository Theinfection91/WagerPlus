using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WagerPlus.Core.Models
{
    public class Condition
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
    }
}
