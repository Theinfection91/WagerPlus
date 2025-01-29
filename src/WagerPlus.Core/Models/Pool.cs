using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WagerPlus.Core.Enums;

namespace WagerPlus.Core.Models
{
    public class Pool
    {
        // Basic Info
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required WagerType WagerType { get; set; }
        public DateTime CreatedOn { get; set; }

        // Dynamic Info
        public bool isOpen { get; set; }
        public decimal? Odds { get; set; }
        public int Amount { get; set; }
        public List<Wager> Wagers { get; set; }

        public Pool(string name, WagerType wagerType, string? description = null)
        {
            Id = new(); 
            Name = name;
            Description = description;
            WagerType = wagerType;
            isOpen = false;
            Wagers = [];
            CreatedOn = DateTime.Now;
        }
    }
}
